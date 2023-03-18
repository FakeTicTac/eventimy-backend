using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Chat Participant Implementation. Defines Specific Entity Rows for Chat Participant.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatParticipant : DomainEntityId
{
    /// <summary>
    /// Defines Chat Participant Nickname Entity Row.
    /// </summary>
    public string? Nickname { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Participant Belonging To The Chat ID.
    /// </summary>
    public Guid ChatId { get; set; }
    
    /// <summary>
    /// Defines Chat Participant Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}