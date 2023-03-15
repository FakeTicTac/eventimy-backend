using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Country Implementation. Defines Specific Entity Rows for Country.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Country : DomainEntityMetaId
{

    /// <summary>
    /// Defines Country Name (Estonia, Russia and etc.) Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();

    /// <summary>
    /// Defines Country Alpha 3 Code (EST, RUS and etc.) Entity Row.
    /// </summary>
    [MinLength(3)][MaxLength(3)]
    public string? Alpha3Code { get; set; }

    /// <summary>
    /// Defines Cover Image For Country on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To The Country Cities.
    /// </summary>
    public ICollection<City>? Cities { get; set; }
}