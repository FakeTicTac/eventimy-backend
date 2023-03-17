using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Reaction Type Implementation. Defines Specific Entity Rows for Reaction Type.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ReactionType : DomainEntityId
{
    /// <summary>
    /// Defines Reaction Type Title (Like, Dislike and etc.) 
    /// </summary>
    public LanguageString Title { get; set; } = new();


    /// <summary>
    /// Defines Sign Image Path on The Server Side Entity Row.
    /// </summary>
    public string? SignImagePath { get; set; }
}