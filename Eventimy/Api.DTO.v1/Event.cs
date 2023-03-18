using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Event Implementation. Defines Specific Entity Rows for Event. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Event : DomainEntityId
{
    /// <summary>
    /// Defines Event Title Entity Row.
    /// </summary>
    public LanguageString Title { get; set; } = new();

    /// <summary>
    /// Defines Event Summary (Short Representation of Ongoing) Entity Row.
    /// </summary>
    public LanguageString Summary { get; set; } = new();

    /// <summary>
    /// Defines Event Description Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();

    /// <summary>
    /// Defines Event Main Website Entity Row.
    /// </summary>
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
    public byte[]? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines Event Thumbnail Image Path on Server Side Entity Row.
    /// </summary>
    public byte[]? ThumbNailImage { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Belonging To The City ID.
    /// </summary>
    public Guid CityId { get; set; }

    /// <summary>
    /// Defines Event Belonging To The Parent Event ID.
    /// </summary>
    public Guid? ParentEventId { get; set; }

    /// <summary>
    /// Defines Event Belonging To The Event Category Type ID.
    /// </summary>
    public Guid? EventCategoryId { get; set; }
    
    /// <summary>
    /// Defines Event Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}
