using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application City Implementation. Defines Specific Entity Rows for City. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class City : DomainEntityId
{
    /// <summary>
    /// Defines City Name (Tallinn, Leeds and etc.) Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();

    /// <summary>
    /// Defines City Alpha 3 Code (TLN, AST and etc.) Entity Row.
    /// </summary>
    public string? Alpha3Code { get; set; }

    /// <summary>
    /// Defines Cover Image For City on The Server Side Entity Row.
    /// </summary>
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines City Belonging To The Country ID.
    /// </summary>
    public Guid CountryId { get; set; }
}