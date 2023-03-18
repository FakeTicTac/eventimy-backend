using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Performer Implementation. Defines Specific Entity Rows for Performer. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Performer : DomainEntityId
{
    /// <summary>
    /// Defines Performer Name (AC/DC, Imagine Dragons and etc.) Entity Row.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Defines Performer Description Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();

    /// <summary>
    /// Defines Cover Image For Performer on The Server Side Entity Row.
    /// </summary>
    public byte[]? CoverImage { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Performer Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }

    /// <summary>
    /// Defines Performer Belonging To The Performer Type ID.
    /// </summary>
    public Guid PerformerTypeId { get; set; }

    /// <summary>
    /// Defines Performer Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}
