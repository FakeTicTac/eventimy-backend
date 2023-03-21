using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Country Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class CountryController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Country Mapper Connection Definition.
    /// </summary>
    private readonly CountryMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CountryController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new CountryMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Countries.
    /// </summary>
    /// <returns>IEnumerable of Countries.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Country>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries() =>
        Ok((await _bll.Countries.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Country.
    /// </summary>
    /// <param name="id">Country ID Value To Search For Country.</param>
    /// <returns>Country Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Country>> GetCountry(Guid id)
    {
        var country = await _bll.Countries.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (country == null) return NotFound();
        
        return _mapper.Map(country)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Country In Database Layer.
    /// </summary>
    /// <param name="id">Country ID Value of Country To Be Updated.</param>
    /// <param name="country">Defines Country Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> PutCountry(Guid id, Country country)
    {
        if (!id.Equals(country.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.Countries.Update(_mapper.Map(country)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Country Record In Database Layer.
    /// </summary>
    /// <param name="country">Object Value To Be Created In Database.</param>
    /// <returns>Created Country Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<ActionResult<Chat>> PostCountry(Country country)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllCountry = _bll.Countries.Add(_mapper.Map(country)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new
        {
            id = bllCountry.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllCountry);
    }

    /// <summary>
    /// Method Deletes Country In The Database Layer.
    /// </summary>
    /// <param name="id">Country ID Value of Country To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> DeleteCountry(Guid id)
    {
        // Try To Get Record From Database.
        var country = await _bll.Countries.FirstOrDefaultAsync(id);

        if (country == null) return NotFound();
        
        // Remove Existed Record.
        _bll.Countries.Remove(country);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}