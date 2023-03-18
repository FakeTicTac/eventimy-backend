using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1.Identity;


/// <summary>
/// Application Identity Register Implementation. Defines Specific Entity Rows for Identity Register. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global

public class Register
{
    /// <summary>
    /// Defines Registration Email Sent From Client.
    /// </summary>
    [StringLength(128, MinimumLength = 5, ErrorMessage = "Wrong Length of Email")]
    public string? Email { get; set; } 
        
    /// <summary>
    /// Defines Registration Username Sent From Client.
    /// </summary>
    public string? UserName { get; set; }
    
    /// <summary>
    /// Defines Registration Password Sent From Client.
    /// </summary>
    public string? Password { get; set; }
}