using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Event Category Implementation. Defines Specific Entity Rows for Event Category. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class EventCategory : DomainEntityMetaId
{
    /// <summary>
    /// Defines Event Category Title (Medicine and Beauty, Gaming and etc.) Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Title { get; set; } = new();

    /// <summary>
    /// Defines Event Category Description Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();

    /// <summary>
    /// Defines Event Category Sign Image Path on Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? SignImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Category Belonging To The Parent Event Category ID.
    /// </summary>
    [ForeignKey("ParentCategory")]
    public Guid? ParentCategoryId { get; set; }
    
    /// <summary>
    /// Defines Event Category Belonging To The Parent Event Category.
    /// </summary>
    public EventCategory? ParentCategory { get; set; }
    
    /// <summary>
    /// Defines All Related To Main Event Category Children Event Categories.
    /// </summary>
    [InverseProperty("ParentCategory")]
    public ICollection<EventCategory>? ChildrenEventCategories { get; set; }
    
    /// <summary>
    /// Defines All Related To Event Category Events.
    /// </summary>
    public ICollection<Event>? Events { get; set; }
}