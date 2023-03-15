using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Event Reaction Implementation. Defines Specific Entity Rows for Event Reaction.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class EventReaction : DomainEntityUser<AppUser>, IDomainEntityId
{
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Reaction Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }
    
    /// <summary>
    /// Defines Event Reaction Belonging To The Event.
    /// </summary>
    public Event? Event { get; set; }

    /// <summary>
    /// Defines Event Reaction Belonging To The Reaction Type ID.
    /// </summary>
    public Guid ReactionTypeId { get; set; }
    
    /// <summary>
    /// Defines Event Reaction Belonging To The Reaction Type.
    /// </summary>
    public ReactionType? ReactionType { get; set; }
}