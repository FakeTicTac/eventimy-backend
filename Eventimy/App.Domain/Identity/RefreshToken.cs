using Base.Domain;
using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain.Identity;


/// <summary>
/// Application Refresh Token Implementation. Defines Specific Entity Rows for Identity Refresh Token. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class RefreshToken : DomainEntityUser<AppUser>, IDomainEntityId
{
    /// <summary>
    /// Defines Token Signature Entity Row. 
    /// </summary>
    [MinLength(36)] [MaxLength(36)]
    public string? Signature { get; set; }
    
    /// <summary>
    /// Defines Token Signature Expiration Date and Time Entity Row. 
    /// </summary>
    public DateTime ExpirationDateTime { get; set; }

    /// <summary>
    /// Defines Previous Token Signature Entity Row. 
    /// </summary>
    [MinLength(36)] [MaxLength(36)]
    public string? PreviousSignature { get; set; }
    
    /// <summary>
    /// Defines Previous Token Signature Expiration Date and Time Entity Row. 
    /// </summary>
    public DateTime? PreviousExpirationDateTime { get; set; }
}