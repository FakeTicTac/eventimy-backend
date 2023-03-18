using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Poll Answer Implementation. Defines Specific Entity Rows for Poll Answer. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PollAnswer : DomainEntityId
{
    /// <summary>
    /// Defines Poll Answer Belonging To The Chat Participant ID.
    /// </summary>
    public Guid ChatParticipantId { get; set; }

    /// <summary>
    /// Defines Poll Answer Belonging To The Poll Option ID.
    /// </summary>
    public Guid PollOptionId { get; set; }
}