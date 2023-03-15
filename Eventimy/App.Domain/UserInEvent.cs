using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Event Visible To User Implementation. Defines Specific Entity Rows for Event Visible To User. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class UserInEvent : DomainEntityUser<AppUser>, IDomainEntityId
{
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