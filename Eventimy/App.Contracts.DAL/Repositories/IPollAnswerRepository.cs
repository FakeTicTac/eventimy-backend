using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Poll Answer Data Access Layer Repository Design: Basic and Custom Poll Answer Repository Methods.
/// </summary>
public interface IPollAnswerRepository : IEntityRepository<PollAnswer>, IPollAnswerRepositoryCustom<PollAnswer> { }


/// <summary>
/// Poll Answer Data Access Layer Repository Design: Custom Poll Answer Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IPollAnswerRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Poll Answer.
    
    /* Poll Answers Are Not Public Thing And Not Everybody Can See It.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Poll Answers By Given Poll Option.
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Poll Answers By Given Poll Option Asynchronously.
    /// </summary>
    /// <param name="pollOptionId">Defines Poll Option ID To Search For Poll Answers.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByPollOptionIdAsync(Guid pollOptionId, bool noTracking = true);
}