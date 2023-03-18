using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application User Event Rating Implementation. Defines Specific Entity Rows for User Event Rating. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global

public class UserEventRating : DomainEntityId
{
    /// <summary>
    /// Defines User Event Rating Value.
    /// </summary>
    public int? RatingValue { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines User Event Rating Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }
    
    /// <summary>
    /// Defines User Event Rating Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}