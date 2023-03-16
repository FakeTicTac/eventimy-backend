using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Chat Poll Data Access Layer Repository Design: Basic and Custom Chat Poll Repository Methods. 
/// </summary>
public interface IChatPollRepository : IEntityRepository<ChatPoll>, IChatPollRepositoryCustom<ChatPoll> { }


/// <summary>
/// Chat Poll Data Access Layer Repository Design: Custom Chat Poll Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IChatPollRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Chat Poll Repository.
    
    /* Chats Are Not In Public Access:
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access Chat Polls By Chat.
     *  - Users Can Access Chat Polls By Chat And Partial Title.
     *  - Users Can Access Chat Polls By Chat Member.
     * 
     */

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Polls By Given Chat Value.
    /// </summary>
    /// <param name="chatId">Defines Chat ID Value To Search For Polls.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>synchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatId(Guid chatId, bool noTracking = true);
}
