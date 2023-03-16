using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Event Visible To User Data Access Layer Repository Design: Basic and Custom Event Visible To User Repository Methods.
/// </summary>
public interface IUserEventRatingRepository : IEntityRepository<UserEventRating>, 
    IUserEventRatingRepositoryCustom<UserEventRating> { }


/// <summary>
/// Event Visible To User Data Access Layer Repository Design: Custom Event Visible To User Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IUserEventRatingRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Event Visible To User. (No Security Applied On This Level)

    /* Event Visible To Users Are Public Thing And Everybody Can See It.
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Get All Related To Event User Ratings.
     *
     */

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Event Ratings of Given Event.
    /// </summary>
    /// <param name="eventId">Defines Event ID Value To Search For Event Ratings.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllByEventIdAsync(Guid eventId, bool noTracking = true);
}