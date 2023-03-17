using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;



/// <summary>
/// Application Performer Type Implementation. Defines Specific Entity Rows for Performer Type. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PerformerType : DomainEntityId
{
    /// <summary>
    /// Defines Performer Type Title (Rock Band, Speaker and etc.). 
    /// </summary>
    public LanguageString Title { get; set; } = new();
    
    /// <summary>
    /// Defines Sign Image For Performer Type on The Server Side Entity Row.
    /// </summary>
    public string? SignImagePath { get; set; }
}