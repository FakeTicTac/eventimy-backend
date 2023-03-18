using App.DAL.EF;
using System.Net;
using Base.Extensions;
using Api.DTO.v1.Errors;
using System.Diagnostics;
using Api.DTO.v1.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

using AppUser = App.Domain.Identity.AppUser;


namespace WebApp.ApiControllers.Identity;


/// <summary>
/// API Controller For Account Manipulations And Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/identity/[controller]/[action]")]
public class AccountController : ControllerBase
{ 
    
    /// <summary>
    /// Defines Connection API For User Sign In Operations.
    /// </summary>
    private readonly SignInManager<AppUser> _signInManager;
    
    /// <summary>
    /// Defines Connection API For User Managing Operations.
    /// </summary>
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Defines Logging Connection.
    /// </summary>
    private readonly ILogger<AccountController> _logger;
    
    /// <summary>
    /// Defines Connection To Application Configurations.
    /// </summary>
    private readonly IConfiguration _configuration;
    
    /// <summary>
    /// Defines Connection To Random Generator.
    /// </summary>
    private readonly Random _rnd = new();
    
    /// <summary>
    /// Defines Connection To Database Layer.
    /// </summary>
    private readonly AppDbContext _appDbContext;

    
    /// <summary>
    /// Basic Account Controller Constructor.
    /// </summary>
    /// <param name="signInManager">Defines Connection API For User Sign In Operations.</param>
    /// <param name="userManager">Defines Connection API For User Managing Operations.</param>
    /// <param name="logger">Defines Logging Connection.</param>
    /// <param name="configuration">Defines Connection To Application Configurations.</param>
    /// <param name="appDbContext">Defines Connection To Database Layer.</param>
    public AccountController(
        SignInManager<AppUser> signInManager, 
        UserManager<AppUser> userManager, 
        ILogger<AccountController> logger, 
        IConfiguration configuration, 
        AppDbContext appDbContext)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
        _configuration = configuration;
        _appDbContext = appDbContext;
    }
    
    
    /// <summary>
    /// Login Into The Rest Backend - Generates JWT To Be Included In
    /// Authorize: Bearer xyz
    /// </summary>
    /// <param name="login">Supply Email and Password</param>
    /// <returns>JWT And Refresh Token</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Jwt>> LogIn([FromBody] Login login)
    {
        // Verify Username 
        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user == null)
        {
            _logger.LogWarning("WebApi login failed, email {} not found", login.Email);
            await Task.Delay(_rnd.Next(100, 1000));
            return NotFound("User/Password problem");
        }

        
        // Verify Username And Password
        var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

        if (!result.Succeeded)
        {
            _logger.LogWarning("WebApi login failed, password problem for user {}", login.Email);
            await Task.Delay(_rnd.Next(100, 1000));
            return NotFound("User/Password problem");
        }

        // Get Claims Based User
        var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

        if (claimsPrincipal == null)
        {
            _logger.LogWarning("WebApi, Cannot Get Claims Principal for User {}", login.Email);
            await Task.Delay(_rnd.Next(100, 1000));
            return NotFound("User/Password problem");
        }

        
        // Handle Old Tokens
        user.RefreshTokens = await _appDbContext
            .Entry(user)
            .Collection(a => a.RefreshTokens!)
            .Query()
            .Where(t => t.AppUserId == user.Id)
            .ToListAsync();

        foreach (var userRefreshToken in user.RefreshTokens)
        {
            if (userRefreshToken.ExpirationDateTime < DateTime.UtcNow &&
                userRefreshToken.PreviousExpirationDateTime < DateTime.UtcNow)
            {
                _appDbContext.RefreshTokens.Remove(userRefreshToken);
            }
        }
        
        // Create New Tokens
        var refreshToken = new App.Domain.Identity.RefreshToken
        {
            AppUserId = user.Id,
            Signature = Guid.NewGuid().ToString(),
            ExpirationDateTime = DateTime.UtcNow.AddDays(7)
        };
        
        _appDbContext.RefreshTokens.Add(refreshToken);
        await _appDbContext.SaveChangesAsync();
        
        // Generate JWT
        var jwt = IdentityExtensions.GenerateJwt(
            claimsPrincipal.Claims,
            _configuration["JWT:Key"],
            _configuration["JWT:issuer"],
            _configuration["JWT:issuer"],
            DateTime.Now.AddMinutes(_configuration.GetValue<int>("JWT:ExpireInMinutes")));

        
        // Get Roles
        var roles = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

        var userRole = "";

        if (roles.Count != 0) userRole = roles[0];
        
        
        var res = new Jwt
        {
            TokenValue = jwt,
            RefreshTokenValue = refreshToken.Signature,
            Username = user.UserName,
            Role = userRole
        };

        return Ok(res);
    }

    /// <summary>
    /// Register Into The Rest Backend - Generates JWT To Be Included In
    /// Authorize: Bearer xyz
    /// </summary>
    /// <param name="register">Supply Email and Password and Username (Optional)</param>
    /// <returns>JWT And Refresh Token</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Jwt>> Register([FromBody] Register register)
    {
        // Verify User
        var user = await _userManager.FindByEmailAsync(register.Email);

        if (user != null)
        {
            _logger.LogWarning("WebApi with email {} is already registered", register.Email);
            var errorResponse = new RestApiError
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "WebApi Error",
                Status = HttpStatusCode.BadRequest,
                TraceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Errors =
                {
                    ["email"] = new List<string>() { "Email already registered." }
                }
            };

            return BadRequest(errorResponse);
        }
        
        // Create User
        user = new AppUser
        {
            Email = register.Email,
            UserName = register.UserName,
        };

        var result = await _userManager.CreateAsync(user, register.Password);
        
        // Operation Failed?
        if (!result.Succeeded) return BadRequest(result);
  
        
        // Get Full User
        user = await _userManager.FindByEmailAsync(user.Email);

        if (user == null)
        {
            _logger.LogWarning("WebApi with email {} is not found after registration", register.Email);
            return BadRequest("Email is not found after registration");
        }
        
        
        var refreshToken = new App.Domain.Identity.RefreshToken
        {
            AppUserId = user.Id,
            Signature = Guid.NewGuid().ToString(),
            ExpirationDateTime = DateTime.UtcNow.AddDays(7)
        };
        
        _appDbContext.RefreshTokens.Add(refreshToken);
        await _appDbContext.SaveChangesAsync();
        
        
        // Get Claims Based User
        var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

        if (claimsPrincipal == null)
        {
            _logger.LogWarning("WebApi, Cannot Get Claims Principal for User {}", register.Email);
            await Task.Delay(_rnd.Next(100, 1000));
            return NotFound("User/Password problem");
        }

        
        // Generate JWT
        var jwt = IdentityExtensions.GenerateJwt(
            claimsPrincipal.Claims,
            _configuration["JWT:Key"],
            _configuration["JWT:issuer"],
            _configuration["JWT:issuer"],
            DateTime.Now.AddMinutes(_configuration.GetValue<int>("JWT:ExpireInMinutes")));

        
        // Get Roles
        var roles = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

        var userRole = "";

        if (roles.Count != 0) userRole = roles[0];
        
        var res = new Jwt
        {
            RefreshTokenValue = refreshToken.Signature,
            TokenValue = jwt,
            Role = userRole,
            Username = user.UserName
        };

        return Ok(res);
    }

    /// <summary>
    /// Refresh Token In The Rest Backend - Generates JWT To Be Included In
    /// Authorize: Bearer xyz
    /// </summary>
    /// <param name="refreshToken">Supply With Refresh Token.</param>
    /// <returns>JWT And Refresh Token</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Jwt>> RefreshToken([FromBody] Token refreshToken)
    {
        
        // Get User Info From JWT

        JwtSecurityToken token;
        
        try
        {
            token = new JwtSecurityTokenHandler().ReadJwtToken(refreshToken.TokenValue);
        }
        catch (Exception)
        {
            return BadRequest("Can't parse token.");
        }
        
        
        // Validate Token Signature.

        
        var userEmail = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (userEmail == null) return BadRequest("No email in jwt token.");
        
        // Get User And Tokens

        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null) return NotFound($"User with email {userEmail} not found");
        
        await _appDbContext.Entry(user)
            .Collection(x => x.RefreshTokens!)
            .Query()
            .Where(x => x.Signature == refreshToken.RefreshTokenValue && x.ExpirationDateTime > DateTime.UtcNow ||
                                  x.PreviousSignature == refreshToken.RefreshTokenValue &&
                                  x.PreviousExpirationDateTime > DateTime.UtcNow)
            .ToListAsync();

        if (user.RefreshTokens == null) return Problem("RefreshTokens collection is null");

        if (user.RefreshTokens.Count == 0) 
            return Problem("RefreshTokens collection is empty, no valid refresh tokens found");

        if (user.RefreshTokens.Count > 1) return Problem("More than one valid refresh token found.");
        
        // New JWT
        // Get Claims based user
        var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

        if (claimsPrincipal == null)
        {
            _logger.LogWarning("WebApi, Cannot Get Claims Principal for User {}", userEmail);
            await Task.Delay(_rnd.Next(100, 1000));
            return NotFound("User/Password problem");
        }

        // Generate JWT
        var jwt = IdentityExtensions.GenerateJwt(
            claimsPrincipal.Claims,
            _configuration["JWT:Key"],
            _configuration["JWT:issuer"],
            _configuration["JWT:issuer"],
            DateTime.Now.AddMinutes(_configuration.GetValue<int>("JWT:ExpireInMinutes")));


        var newRefreshToken = user.RefreshTokens.First();

        if (newRefreshToken.Signature == refreshToken.RefreshTokenValue)
        {
            newRefreshToken.PreviousSignature = newRefreshToken.Signature;
            newRefreshToken.PreviousExpirationDateTime = DateTime.UtcNow.AddMinutes(1);
            newRefreshToken.Signature = Guid.NewGuid().ToString();
            newRefreshToken.ExpirationDateTime = DateTime.UtcNow.AddDays(7);
        }

        _appDbContext.Update(newRefreshToken);
        await _appDbContext.SaveChangesAsync();
        
        // Get Roles
        var roles = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

        var userRole = "";

        if (roles.Count != 0) userRole = roles[0];
        
        var res = new Jwt
        {
            RefreshTokenValue = newRefreshToken.Signature,
            TokenValue = jwt,
            Role = userRole,
            Username = user.UserName
        };

        return Ok(res);
    }
}
