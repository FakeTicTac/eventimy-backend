using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Performer Type Implementation. Defines Specific Entity Rows for Performer Type. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PerformerType : DomainEntityMetaId
{
    /// <summary>
    /// Defines Performer Type Title (Rock Band, Speaker and etc.). 
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// Defines Sign Image For Performer Type on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? SignImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related to Performer Type Performers.
    /// </summary>
    public ICollection<Performer>? Performers { get; set; }
}