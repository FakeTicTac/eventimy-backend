using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Event Data Access Layer Repository Design: Basic and Custom Event Repository Methods.
/// </summary>
public interface IEventRepository: IEntityRepository<Event>, IEventRepositoryCustom<Event> { }


/// <summary>
/// Event Data Access Layer Repository Design: Custom Event Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IEventRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Event Repository.
    
    /* Event In Some Way Secure Thing And Not Everybody Can See It.
     *
     * *** Already Covered In Basic Implementation. ***
     * - Users Can Access All Public Events, Private Events Where User Is Invited To And Own Events. (GetAll Rewrite)
     *
     * *** Not Covered In Basic Implementation. ***
     * - Users Can Access All Public Events.
     * - Users Can Access All Events Where They Invited To.
     * - Users Can Access All Events Where They Are Creators.
     * - Users Can Access All Children Events Of Parent Event.
     *
     */
}