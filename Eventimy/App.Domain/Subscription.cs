using Base.Domain;
using App.Domain.Identity;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Subscription Implementation. Defines Specific Entity Rows for Subscription.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Subscription : DomainEntityMetaId
{
    /// <summary>
    /// Defines Subscription Acceptance from Recipient.
    /// </summary>
    public bool IsAccepted { get; set; }
    
    
    // EF CORE Related Relations Are Going Next --> 
    
    
    /// <summary>
    /// Defines Subscription Belonging To The User Sender ID.
    /// </summary>
    [ForeignKey("Sender")]
    public Guid SenderUserId { get; set; }
    
    /// <summary>
    /// Defines Subscription Belonging To The User Sender
    /// </summary>
    public AppUser? Sender { get; set; }
    
    /// <summary>
    /// Defines Subscription Belonging To The User Recipient ID.
    /// </summary>
    [ForeignKey("Recipient")]
    public Guid RecipientUserId { get; set; }
    
    /// <summary>
    /// Defines Subscription Belonging To The User Recipient.
    /// </summary>
    public AppUser? Recipient { get; set; }
}