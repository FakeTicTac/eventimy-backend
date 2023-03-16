using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Event Category Data Access Layer Repository Design: Basic and Custom Event Category Repository Methods. 
/// </summary>
public interface IEventCategoryRepository : IEntityRepository<EventCategory>, 
    IEventCategoryRepositoryCustom<EventCategory> { }


/// <summary>
/// Event Category Data Access Layer Repository Design: Custom Event Category Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IEventCategoryRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Event Category Repository. (No Security Applied On This Level For Accessing)
 
    /* Event Categories Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Event Categories. (Visible Absolutely To Everyone)
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Children Event Categories By Parent Category ID.
     * 
     */
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Event Categories With Particular Parent Event Category Asynchronously.
    /// </summary>
    /// <param name="parentEventCategoryId">Defines Parent Event Category ID.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByParentEventCategoryAsync(Guid parentEventCategoryId, bool noTracking = true);
}