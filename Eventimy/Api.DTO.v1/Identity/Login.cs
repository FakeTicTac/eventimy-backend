using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1.Identity;


/// <summary>
/// Application Identity Login Implementation. Defines Specific Entity Rows for Identity Login. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Login
{
    /// <summary>
    /// Defines Login Email Sent From Client.
    /// </summary>
    [StringLength(128, MinimumLength = 5, ErrorMessage = "Wrong Length of Email")]
    public string? Email { get; set; } 
    
    /// <summary>
    /// Defines Login Password Sent From Client.
    /// </summary>
    public string? Password { get; set; }
}