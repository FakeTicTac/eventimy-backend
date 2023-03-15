using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Reaction Type Implementation. Defines Specific Entity Rows for Reaction Type.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ReactionType : DomainEntityMetaId
{
    /// <summary>
    /// Defines Reaction Type Title (Like, Dislike and etc.) 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Title { get; set; } = new();


    /// <summary>
    /// Defines Sign Image Path on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? SignImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related to Reaction Type Event Reactions.
    /// </summary>
    public ICollection<EventReaction>? EventReactions { get; set; }
}