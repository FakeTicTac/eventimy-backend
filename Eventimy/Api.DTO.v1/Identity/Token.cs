
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1.Identity;


/// <summary>
/// Application Identity Token Implementation. Defines Specific Entity Rows for Identity Token. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Token
{
    /// <summary>
    /// Defines Token Refreshment Token Sent From Client.
    /// </summary>
    public string? TokenValue { get; set; }

    /// <summary>
    /// Defines Token Refreshment Refresh Token Sent From Client.
    /// </summary>
    public string? RefreshTokenValue { get; set; }
}