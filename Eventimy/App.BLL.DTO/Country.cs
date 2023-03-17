using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Country Implementation. Defines Specific Entity Rows for Country.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Country : DomainEntityId
{
    /// <summary>
    /// Defines Country Name (Estonia, Russia and etc.) Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();

    /// <summary>
    /// Defines Country Alpha 3 Code (EST, RUS and etc.) Entity Row.
    /// </summary>
    public string? Alpha3Code { get; set; }

    /// <summary>
    /// Defines Cover Image For Country on The Server Side Entity Row.
    /// </summary>
    public string? CoverImagePath { get; set; }
}