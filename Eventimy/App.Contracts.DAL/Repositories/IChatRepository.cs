using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Chat Data Access Layer Repository Design: Basic and Custom Chat Repository Methods. 
/// </summary>
public interface IChatRepository : IEntityRepository<Chat>, IChatRepositoryCustom<Chat> { }


/// <summary>
/// Chat Data Access Layer Repository Design: Custom Chat Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IChatRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Chat Repository. (Some Level Of Security Applied On This Level For Accessing)
    
    // Main Point Of Application Data Loading - A Lot Of Small Requests Instead Of One And Big.

    /* Chats Are Not In Public Access:
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access Chats Where They Are Participants or Creators. (When Person Create Chat He Is Also Participant)
     *  Basic "GetAllAsync" Should Return This Type Of Data.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access Chats Where They Are Participants By Part Of Its' Title.
     *  - Users Can Access Chat Of Given Event. (Not Secure Here)
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets Chats Of The Given Event ID Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Entity.</returns>
    public Task<TEntity?> GetChatByEventIdAsync(Guid eventId, bool noTracking = true);
}
