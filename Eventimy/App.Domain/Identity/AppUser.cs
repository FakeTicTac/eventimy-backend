using Base.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain.Identity;


/// <summary>
/// Application Identity User Implementation. Defines Specific Entity Rows for Identity User. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class AppUser : BaseUser
{
    /// <summary>
    /// Defines User First Name Entity Row. 
    /// </summary>
    [MaxLength(50)]
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Defines User Last Name Entity Row. 
    /// </summary>
    [MaxLength(50)]
    public string? LastName { get; set; }

    /// <summary>
    /// Defines Users' Profile Image Path on The Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? ProfileImagePath { get; set; }
    
    /// <summary>
    /// Defines Users' Profile Cover/Background Image Path on The Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines Users' Account Description Entity Row.
    /// </summary>
    [MaxLength(400)]
    public string? Description { get; set; }


    // EF CORE Related Relations Are Going Next -->
    

    /// <summary>
    /// Defines Created By User Events.
    /// </summary>
    public ICollection<Event>? Events { get; set; }

    /// <summary>
    /// Defines Chats Which are Created By The User.
    /// </summary>
    public ICollection<Chat>? Chats { get; set; }

    /// <summary>
    /// Defines Chats Where User is Participant.
    /// </summary>
    public ICollection<ChatParticipant>? ChatParticipants { get; set; }

    /// <summary>
    /// Defines Which Private Events are Visible To The User.
    /// </summary>
    public ICollection<UserInEvent>? UserInEvents { get; set; }

    /// <summary>
    /// Defines Users' Event Reactions.
    /// </summary>
    public ICollection<EventReaction>? EventReactions { get; set; }
    
    /// <summary>
    /// Defines Users' Event Ratings.
    /// </summary>
    public ICollection<UserEventRating>? UserEventRatings { get; set; }
    
    /// <summary>
    /// Defines Users' Subscriptions as Sender. (Shows People Who User Follows)
    /// </summary>
    [InverseProperty("Sender")]
    public ICollection<Subscription>? SenderSubscriptions { get; set; }
    
    /// <summary>
    /// Defines Users' Subscriptions as Recipient. (Shows People Who Follows User)
    /// </summary>
    [InverseProperty("Recipient")]
    public ICollection<Subscription>? RecipientSubscriptions { get; set; }
    
    /// <summary>
    /// Defines Users' Connection To Performers. (Where User Is Performer)
    /// </summary>
    public ICollection<Performer>? Performers { get; set; }

    /// <summary>
    /// Defines All Users' Refresh Tokens.
    /// </summary>
    public ICollection<RefreshToken>? RefreshTokens { get; set; }
}
