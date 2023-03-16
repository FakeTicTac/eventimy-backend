using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Performer Data Access Layer Repository Design: Basic and Custom Performer Repository Methods.
/// </summary>
public interface IPerformerRepository : IEntityRepository<Performer>, IPerformerRepositoryCustom<Performer> { }


/// <summary>
/// Performer Data Access Layer Repository Design: Custom Performer Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IPerformerRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Performer. (No Security Applied On This Level)
    
    /* Performer Types Are Public (In Some Way) Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Performances Where Given User Performing.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Performers For Given Event.
     *  - Users Can Access All Performers For Given Event Of Given Performer Type.
     *  - Users Can Access All Performers For Given Event That Start Performance At Particular Time.
     *  - Users Can Access All Performers By Given Partial Title.
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Performers Who Perform At Particular Event Asynchronously. 
    /// </summary>
    /// <param name="eventId">Defines Event ID For Performer Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByEventId(Guid eventId, bool noTracking = true);
}
