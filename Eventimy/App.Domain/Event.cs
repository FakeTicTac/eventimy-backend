using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Event Implementation. Defines Specific Entity Rows for Event. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Event : DomainEntityUser<AppUser>, IDomainEntityId
{
    /// <summary>
    /// Defines Event Title Entity Row.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Defines Event Summary (Short Representation of Ongoing) Entity Row.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Defines Event Description Entity Row.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Defines Event Main Website Entity Row.
    /// </summary>
    [MaxLength(260)]
    public string? EventWebsite { get; set; }
    
    /// <summary>
    /// Defines Maximum Amount of Participant Entity Row.
    /// </summary>
    public int? MaxParticipantAmount { get; set; }
    
    /// <summary>
    /// Defines Minimum Amount of Participant Entity Row.
    /// </summary>
    public int? MinParticipantAmount { get; set; }
    
    /// <summary>
    /// Defines Event Ticket Coordinator Website.
    /// </summary>
    [MaxLength(260)]
    public string? TicketBuyingWebsite { get; set; }
    
    /// <summary>
    /// Defines Event Privacy (Visible to Everyone or Limited Amount of Users) Entity Row.
    /// </summary>
    public bool IsPrivate { get; set; }
    
    /// <summary>
    /// Defines Event Entrance Fee (Is Free or Not) Entity Row.
    /// </summary>
    public bool IsFree { get; set; }

    /// <summary>
    /// Defines Event Address Location Entity Row.
    /// </summary>
    [MaxLength(200)]
    public string? Address { get; set; }
    
    /// <summary>
    /// Defines Event Starting Time Entity Row.
    /// </summary>
    public DateTime? StartTime { get; set; }
    
    /// <summary>
    /// Defines Event Ending Time Entity Row.
    /// </summary>
    public DateTime? EndTime { get; set; }
    
    /// <summary>
    /// Defines Latitude Coordinate Of The Event.
    /// </summary>
    public float? Latitude { get; set; }
    
    /// <summary>
    /// Defines Longitude Coordinate Of The Event.
    /// </summary>
    public float? Longitude { get; set; }
    
    /// <summary>
    /// Defines Event Cover Image Path on Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines Event Thumbnail Image Path on Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? ThumbNailImage { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Belonging To The City ID.
    /// </summary>
    public Guid CityId { get; set; }
    
    /// <summary>
    /// Defines Event Belonging To The City.
    /// </summary>
    public City? City { get; set; }
    
    /// <summary>
    /// Defines Event Belonging To The Parent Event ID.
    /// </summary>
    [ForeignKey("ParentEvent")]
    public Guid? ParentEventId { get; set; }
    
    /// <summary>
    /// Defines Event Belonging To The Parent Event.
    /// </summary>
    public Event? ParentEvent { get; set; }

    /// <summary>
    /// Defines Event Belonging To The Event Category Type ID.
    /// </summary>
    public Guid? EventCategoryId { get; set; }
    
    /// <summary>
    /// Defines Event Belonging To The Event Category Type.
    /// </summary>
    public EventCategory? EventCategory { get; set; }

    /// <summary>
    /// Defines All Related To Main Event Children Events.
    /// </summary>
    [InverseProperty("ParentEvent")]
    public ICollection<Event>? ChildrenEvents { get; set; }

    /// <summary>
    /// Defines All Related To Event Performers.
    /// </summary>
    public ICollection<Performer>? Performers { get; set; }

    /// <summary>
    /// Defines All Users To Whom Event is Visible.
    /// </summary>
    public ICollection<UserEventRating>? UserEventRatings { get; set; }

    /// <summary>
    /// Defines All Related To Event Users.
    /// </summary>
    public ICollection<UserInEvent>? UserInEvents { get; set; }

    /// <summary>
    /// Defines All Related To Event Media Files.
    /// </summary>
    public ICollection<EventMediaFile>? EventMediaFiles { get; set; }

    /// <summary>
    /// Defines All Related To Event Reactions.
    /// </summary>
    public ICollection<EventReaction>? EventReactions { get; set; }
    
    /// <summary>
    /// Defines All Related To Event Chats.
    /// </summary>
    public ICollection<Chat>? Chats { get; set; }
}
