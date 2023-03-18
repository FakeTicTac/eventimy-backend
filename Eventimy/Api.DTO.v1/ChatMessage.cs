using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Chat Message Implementation. Defines Specific Entity Rows for Chat Message. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatMessage : DomainEntityId
{
    /// <summary>
    /// Defines Chat Message Content Entity Row.
    /// </summary>
    public string? Content { get; set; }
    
    /// <summary>
    /// Defines Message Being Pinned In Chat.
    /// </summary>
    public bool IsPinned { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Message Belonging To The Chat ID.
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Defines Chat Message Belonging To The Chat Participant ID.
    /// </summary>
    public Guid ChatParticipantId { get; set; }
}
