using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application User Event Rating Implementation. Defines Specific Entity Rows for User Event Rating. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global

public class UserEventRating : DomainEntityUser<AppUser>, IDomainEntityId
{
    /// <summary>
    /// Defines User Event Rating Value.
    /// </summary>
    public int? RatingValue { get; set; }
    
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Visible To User Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }
    
    /// <summary>
    /// Defines Event Visible To User Belonging To The Event.
    /// </summary>
    public Event? Event { get; set; }
}