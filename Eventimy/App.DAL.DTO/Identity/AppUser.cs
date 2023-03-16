using Base.Domain.Identity;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO.Identity;


/// <summary>
/// Application Identity User Implementation. Defines Specific Entity Rows for Identity User. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class AppUser : BaseUser
{
    /// <summary>
    /// Defines User First Name Entity Row. 
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Defines User Last Name Entity Row. 
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Defines Users' Profile Image Path on The Server Side Entity Row.
    /// </summary>
    public byte[]? ProfileImagePath { get; set; }
    
    /// <summary>
    /// Defines Users' Profile Cover/Background Image Path on The Server Side Entity Row.
    /// </summary>
    public byte[]? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines Users' Account Description Entity Row.
    /// </summary>
    public string? Description { get; set; }
}
