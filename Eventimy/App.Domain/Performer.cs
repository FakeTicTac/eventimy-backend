using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Performer Implementation. Defines Specific Entity Rows for Performer. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Performer : DomainEntityUser<AppUser>, IDomainEntityId
{
    /// <summary>
    /// Defines Performer Name (AC/DC, Imagine Dragons and etc.) Entity Row.
    /// </summary>
    [MinLength(1)][MaxLength(100)]
    public string? Name { get; set; }

    /// <summary>
    /// Defines Performer Description Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();

    /// <summary>
    /// Defines Cover Image For Performer on The Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? CoverImage { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Performer Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }
    
    /// <summary>
    /// Defines Performer Belonging To The Event.
    /// </summary>
    public Event? Event { get; set; }

    /// <summary>
    /// Defines Performer Belonging To The Performer Type ID.
    /// </summary>
    public Guid PerformerTypeId { get; set; }
    
    /// <summary>
    /// Defines Performer Belonging To The Performer Type.
    /// </summary>
    public PerformerType? PerformerType { get; set; }
}
