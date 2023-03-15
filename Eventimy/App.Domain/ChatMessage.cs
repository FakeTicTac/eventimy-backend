using Base.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Chat Message Implementation. Defines Specific Entity Rows for Chat Message. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatMessage : DomainEntityMetaId
{
    /// <summary>
    /// Defines Chat Message Content Entity Row.
    /// </summary>
    [MinLength(1)][MaxLength(4096)]
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
    /// Defines Chat Message Belonging To The Chat.
    /// </summary>
    public Chat? Chat { get; set; }
    
    /// <summary>
    /// Defines Chat Message Belonging To The Chat Participant ID.
    /// </summary>
    public Guid ChatParticipantId { get; set; }
    
    /// <summary>
    /// Defines Chat Message Belonging To The Chat Participant.
    /// </summary>
    public ChatParticipant? ChatParticipant { get; set; }
    
    /// <summary>
    /// Defines All Related To Chat Message Media Files.
    /// </summary>
    public ICollection<ChatMediaFile>? ChatMediaFiles { get; set; }
}
