using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Chat Media File Data Access Layer Repository Design: Basic and Custom Chat Media File Repository Methods. 
/// </summary>
public interface IChatMediaFileRepository : IEntityRepository<ChatMediaFile>, 
    IChatMediaFileRepositoryCustom<ChatMediaFile> { }


/// <summary>
/// Chat Media File Data Access Layer Repository Design: Custom Chat Media File Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IChatMediaFileRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Chat Media File Repository. (No Security Applied On This Level For Accessing)
    
    // Main Point Of Application Data Loading - A Lot Of Small Requests Instead Of One And Big.

    /* Chats Media Files Are Not In Public Access:
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access Chat Media Files of The Given Chat. (Not Secure Here)
     *  - Users Can Access Chat Media Files of The Given Chat By Given Type. (Not Secure Here)
     *  - Users Can Access Chat Media Files Of The Given Chat In Concrete Chat Message. (Not Secure Here)
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatIdAsync(Guid chatId, bool noTracking = true);

    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat ID And Media File Type ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Media Files.</param>
    /// <param name="mediaFileTypeId">Defines Media File Type ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatAndFileTypeIdAsync(Guid chatId, Guid mediaFileTypeId, bool noTracking = true);

    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat Message ID Asynchronously.
    /// </summary>
    /// <param name="chatMessageId">Defines Chat Message ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatMessageIdAsync(Guid chatMessageId, bool noTracking = true);
}