using System.Text;
using System.ComponentModel;
using System.Security.Claims;
using Base.Extensions.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Base.Extensions;


/// <summary>
/// Class Extends Identity System Capability.
/// </summary>
public static class IdentityExtensions
{

    /// <summary>
    /// Method Gets Currently Logged In Users' ID Value With Already Defined TKey Value as Guid.
    /// </summary>
    /// <param name="user">Defines Users Claims To Be Processed.</param>
    /// <returns>Currently Logged In Users' ID Value.</returns>
    public static Guid GetUserId(this ClaimsPrincipal user) => GetUserId<Guid>(user);
    
    /// <summary>
    /// Method Gets Currently Logged In Users' ID Value.
    /// </summary>
    /// <param name="user">Defines Users Claims To Be Processed.</param>
    /// <typeparam name="TKey">Defines Entity ID Value Type.</typeparam>
    /// <returns>Currently Logged In Users' ID Value.</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    public static TKey GetUserId<TKey>(this ClaimsPrincipal user)
    {
        var idClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        // Check If Name Identifier Is Found.
        if (idClaim == null) throw new IdentifierInClaimExistenceException($"Name identifier for given claim is not found.");

        return (TKey) TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(idClaim.Value)!;
    }

    public static string GenerateJwt(IEnumerable<Claim> claims, string key, string issuer, string audience, DateTime expirationDateTime)
    {

        var stringKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var signingCredentials = new SigningCredentials(stringKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: expirationDateTime,
            signingCredentials: signingCredentials
        );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}