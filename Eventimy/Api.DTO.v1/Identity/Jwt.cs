
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Api.DTO.v1.Identity;


/// <summary>
/// Application Identity JWT Implementation. Defines Specific Entity Rows for Identity JWT. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Jwt
{
    /// <summary>
    /// Defines JWT Token To Be Sent To User.
    /// </summary>
    public string? TokenValue { get; set; }
    
    /// <summary>
    /// Defines Users Username In The Application.
    /// </summary>
    public string? Username { get; set; }
    
    /// <summary>
    /// Defines Users Role In The Application.
    /// </summary>
    public string? Role { get; set; }
    
    /// <summary>
    /// Defines Users Refresh Token In The Application.
    /// </summary>
    public string? RefreshTokenValue { get; set; }
}