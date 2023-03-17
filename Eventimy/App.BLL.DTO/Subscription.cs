using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Subscription Implementation. Defines Specific Entity Rows for Subscription.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Subscription : DomainEntityId
{
    /// <summary>
    /// Defines Subscription Acceptance from Recipient.
    /// </summary>
    public bool IsAccepted { get; set; }
    
    
    // EF CORE Related Relations Are Going Next --> 
    
    
    /// <summary>
    /// Defines Subscription Belonging To The User Sender ID.
    /// </summary>
    public Guid SenderUserId { get; set; }

    /// <summary>
    /// Defines Subscription Belonging To The User Recipient ID.
    /// </summary>
    public Guid RecipientUserId { get; set; }
}