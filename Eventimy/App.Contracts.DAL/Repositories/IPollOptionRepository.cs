using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Poll Option Data Access Layer Repository Design: Basic and Custom Poll Option Repository Methods. 
/// </summary>
public interface IPollOptionRepository : IEntityRepository<PollOption>, IPollOptionRepositoryCustom<PollOption> { }


/// <summary>
/// Poll Option Data Access Layer Repository Design: Custom Poll Option Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IPollOptionRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Poll Option.

    /* Poll Options Are Not Public Thing And Not Everybody Can See It.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Poll Options By Given Chat Poll.
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Poll Options By Given Chat Poll Asynchronously.
    /// </summary>
    /// <param name="chatPollId">Defines Chat Poll ID To Search For Poll Options.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByChatPollIdAsync(Guid chatPollId, bool noTracking = true);
}