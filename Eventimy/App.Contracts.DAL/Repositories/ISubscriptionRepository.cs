using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Subscription Data Access Layer Repository Design: Basic and Custom Subscription Repository Methods.
/// </summary>
public interface ISubscriptionRepository : IEntityRepository<Subscription>, 
    ISubscriptionRepositoryCustom<Subscription> { }


/// <summary>
/// Subscription Data Access Layer Repository Design: Custom Subscription Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface ISubscriptionRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Subscription.

    /* Subscriptions Are Public Thing And Everybody Can See It.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Subscriptions By User Sender. (Who User Subscribed To)
     *  - Users Can Access All Subscriptions By User Recipient. (Whose User Subscribers Are)
     *      
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Subscriptions of Given Sender ID Asynchronously.
    /// </summary>
    /// <param name="senderId">Defines User Sender ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllBySenderIdAsync(Guid senderId, bool noTracking = true);

    /// <summary>
    /// Method Gets All Subscriptions of Given Recipient ID Asynchronously.
    /// </summary>
    /// <param name="recipientId">Defines User Recipient ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByRecipientIdAsync(Guid recipientId, bool noTracking = true);
}