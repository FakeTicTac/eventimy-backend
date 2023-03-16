using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Event Reaction Data Access Layer Repository Design: Basic and Custom Event Reaction Repository Methods.
/// </summary>
public interface IEventReactionRepository : IEntityRepository<EventReaction>, IEventReactionRepositoryCustom<EventReaction> { }


/// <summary>
/// Event Reaction Data Access Layer Repository Design: Custom Achievement Type Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IEventReactionRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Event Reaction Repository. (No Security Applied On This Level For Accessing)
    
    /*  Event Reactions Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Reactions Of The User. (Subscribers To See Data)
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Reactions To The Particular Event.
     * 
     */

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Reactions For The Particular Event Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For Reactions.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByEventAsync(Guid eventId, bool noTracking = true);
}