using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Chat Message Data Access Layer Repository Design: Basic and Custom Chat Message Repository Methods. 
/// </summary>
public interface IChatMessageRepository : IEntityRepository<ChatMessage>, IChatMessageRepositoryCustom<ChatMessage> { }


/// <summary>
/// Chat Message Data Access Layer Repository Design: Custom Chat Message Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IChatMessageRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Chat Message Repository. (No Security Applied On This Level For Accessing)
    
    // Main Point Of Application Data Loading - A Lot Of Small Requests Instead Of One And Big.

    /* Chats Messages Are Not In Public Access:
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access Chat Messages of The Given Chat. (Not Secure Here)
     *  - Users Can Access Chat Messages of The Given Chat By Part Of Its' Content. (Not Secure Here)
     *  - Users Can Access Chat Messages of The Given Chat By User Posted The Message. (Not Secure Here)
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatIdAsync(Guid chatId, bool noTracking = true);

    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID and Its' Partial Content Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="partialContent">Defines Part Of Chat Message Content For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatIdAndPartialContentAsync(Guid chatId, string partialContent, bool noTracking = true);

    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID and Its' Participant ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="participantId">Defines Participant ID To Search For Chat Messages.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatAndParticipantIdAsync(Guid chatId, Guid participantId, bool noTracking = true);
}
