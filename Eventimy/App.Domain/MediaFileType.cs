using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Media Files Implementation. Defines Specific Entity Rows for Media Files.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class MediaFileType : DomainEntityMetaId
{
    /// <summary>
    /// Defines Media File Type Name (Video, Image, Sound) Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Sign Image For Media File Location on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? SignImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To MediaFile Event Media Files.
    /// </summary>
    public ICollection<EventMediaFile>? EventMediaFiles { get; set; }
    
    /// <summary>
    /// Defines All Related To MediaFile Chat Media Files.
    /// </summary>
    public ICollection<ChatMediaFile>? ChatMediaFiles { get; set; }
}