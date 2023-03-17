using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Event Category Implementation. Defines Specific Entity Rows for Event Category. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class EventCategory : DomainEntityId
{
    /// <summary>
    /// Defines Event Category Title (Medicine and Beauty, Gaming and etc.) Entity Row.
    /// </summary>
    public LanguageString Title { get; set; } = new();

    /// <summary>
    /// Defines Event Category Description Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();

    /// <summary>
    /// Defines Event Category Sign Image Path on Server Side Entity Row.
    /// </summary>
    public string? SignImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Category Belonging To The Parent Event Category ID.
    /// </summary>
    public Guid? ParentCategoryId { get; set; }
}