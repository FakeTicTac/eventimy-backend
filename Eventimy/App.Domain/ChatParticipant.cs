using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Chat Participant Implementation. Defines Specific Entity Rows for Chat Participant.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatParticipant : DomainEntityUser<AppUser>, IDomainEntityId
{
    /// <summary>
    /// Defines Chat Participant Nickname Entity Row.
    /// </summary>
    [MinLength(3)][MaxLength(100)]
    public string? Nickname { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Participant Belonging To The Chat ID.
    /// </summary>
    public Guid ChatId { get; set; }
    
    /// <summary>
    /// Defines Chat Participant Belonging To The Chat.
    /// </summary>
    public Chat? Chat { get; set; }

    /// <summary>
    /// Defines All Related To The Chat Participant Messages.
    /// </summary>
    public ICollection<ChatMessage>? ChatMessages { get; set; }

    /// <summary>
    /// Defines All Users' Polls In Chats.
    /// </summary>
    public ICollection<ChatPoll>? ChatPolls { get; set; }
    
    /// <summary>
    /// Defines All Chosen By User Poll Options.
    /// </summary>
    public ICollection<PollAnswer>? PollAnswers { get; set; }
}