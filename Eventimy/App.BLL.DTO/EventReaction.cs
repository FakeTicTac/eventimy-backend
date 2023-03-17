using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Event Reaction Implementation. Defines Specific Entity Rows for Event Reaction.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class EventReaction : DomainEntityId
{
    /// <summary>
    /// Defines Event Reaction Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }

    /// <summary>
    /// Defines Event Reaction Belonging To The Reaction Type ID.
    /// </summary>
    public Guid ReactionTypeId { get; set; }
    
    /// <summary>
    /// Defines Event Reaction Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}