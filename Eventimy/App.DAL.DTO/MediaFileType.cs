using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO;


/// <summary>
/// Application Media Files Implementation. Defines Specific Entity Rows for Media Files.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class MediaFileType : DomainEntityId
{
    /// <summary>
    /// Defines Media File Type Name (Video, Image, Sound) Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Sign Image For Media File Location on The Server Side Entity Row.
    /// </summary>
    public string? SignImagePath { get; set; }
}