using Base.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application City Implementation. Defines Specific Entity Rows for City. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class City : DomainEntityMetaId
{
    /// <summary>
    /// Defines City Name (Tallinn, Leeds and etc.) Entity Row.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Defines City Alpha 3 Code (TLN, AST and etc.) Entity Row.
    /// </summary>
    [MinLength(3)][MaxLength(3)]
    public string? Alpha3Code { get; set; }

    /// <summary>
    /// Defines Cover Image For City on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines City Belonging To The Country ID.
    /// </summary>
    public Guid CountryId { get; set; }
    
    /// <summary>
    /// Defines City Belonging To The Country.
    /// </summary>
    public Country? Country { get; set; }
    
    /// <summary>
    /// Defines All Related To The City Events.
    /// </summary>
    public ICollection<Event>? Events { get; set; }
}