using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Event Media File Data Access Layer Repository Design: Basic and Custom Event Media File Repository Methods.
/// </summary>
public interface IEventMediaFileRepository : IEntityRepository<EventMediaFile>, 
    IEventMediaFileRepositoryCustom<EventMediaFile> { }


/// <summary>
/// Event Media File Data Access Layer Repository Design: Custom Event Media File Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IEventMediaFileRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Event Media File Repository. (No Security Applied On This Level For Accessing) 
    
    /*  Event Media Files Are Public Thing And Everybody Can See It.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Event Media Files To The Particular Event. 
     *  - Users Can Access All Event Media Files To The Particular Event of Given Type.
     * 
     */

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Event Media Files For The Particular Event Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For  Event Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByEventIdAsync(Guid eventId, bool noTracking = true);

    /// <summary>
    /// Method Gets All Event Media Files For The Particular Event of Given Type Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For  Event Media Files.</param>
    /// <param name="mediaFileTypeId">Defines Media File Type ID.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByEventAndFileTypeIdAsync(Guid eventId, Guid mediaFileTypeId, bool noTracking = true);
}
