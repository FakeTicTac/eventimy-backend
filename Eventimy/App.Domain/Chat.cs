using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Chat Implementation. Defines Specific Entity Rows for Chat.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Chat : DomainEntityUser<AppUser>, IDomainEntityId
{
    /// <summary>
    /// Defines Chat Title Entity Row.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Defines Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? ThumbNailImage { get; set; }


    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Belonging To The Event ID.
    /// </summary>
    public Guid? EventId { get; set; }
    
    /// <summary>
    /// Defines Chat Belonging To The Event.
    /// </summary>
    public Event? Event { get; set; }

    /// <summary>
    /// Defines All Related To The Chat Messages.
    /// </summary>
    public ICollection<ChatMessage>? ChatMessages { get; set; }
    
    /// <summary>
    /// Defines All Related To The Chat Participants.
    /// </summary>
    public ICollection<ChatParticipant>? ChatParticipants { get; set; }
    
    /// <summary>
    /// Defines All Related To Chat Media Files.
    /// </summary>
    public ICollection<ChatMediaFile>? ChatMediaFiles { get; set; }
    
    /// <summary>
    /// Defines All Related To Chat Polls.
    /// </summary>
    public ICollection<ChatPoll>? ChatPolls { get; set; }
}
