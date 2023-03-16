using Base.Domain;


// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO.Identity;


/// <summary>
/// Application Refresh Token Implementation. Defines Specific Entity Rows for Identity Refresh Token. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class RefreshToken : DomainEntityId
{
    /// <summary>
    /// Defines Token Signature Entity Row. 
    /// </summary>
    public string? Signature { get; set; }
    
    /// <summary>
    /// Defines Token Signature Expiration Date and Time Entity Row. 
    /// </summary>
    public DateTime ExpirationDateTime { get; set; }

    /// <summary>
    /// Defines Previous Token Signature Entity Row. 
    /// </summary>
    public string? PreviousSignature { get; set; }
    
    /// <summary>
    /// Defines Previous Token Signature Expiration Date and Time Entity Row. 
    /// </summary>
    public DateTime? PreviousExpirationDateTime { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Refresh Token Belonging To The User ID.
    /// </summary>
    public Guid AppUserId { get; set; }
}