using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Event Visible To User Implementation. Defines Specific Entity Rows for Event Visible To User. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class UserInEvent : DomainEntityId
{
    /// <summary>
    /// Defines Event Visible To User Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }
 
    /// <summary>
    /// Defines Chat Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}