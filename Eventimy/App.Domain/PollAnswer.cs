using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Poll Answer Implementation. Defines Specific Entity Rows for Poll Answer. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PollAnswer : DomainEntityMetaId
{
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Poll Answer Belonging To The Chat Participant ID.
    /// </summary>
    public Guid ChatParticipantId { get; set; }
    
    /// <summary>
    /// Defines Poll Answer Belonging To The Chat Participant.
    /// </summary>
    public ChatParticipant? ChatParticipant { get; set; }
    
    /// <summary>
    /// Defines Poll Answer Belonging To The Poll Option ID.
    /// </summary>
    public Guid PollOptionId { get; set; }
    
    /// <summary>
    /// Defines Poll Answer Belonging To The Poll Option.
    /// </summary>
    public PollOption? PollOption { get; set; }
}