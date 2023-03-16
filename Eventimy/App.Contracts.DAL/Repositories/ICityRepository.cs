using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// City Data Access Layer Repository Design: Basic and Custom City Repository Methods. 
/// </summary>
public interface ICityRepository : IEntityRepository<City>, ICityRepositoryCustom<City> { }


/// <summary>
/// City Data Access Layer Repository Design: Custom City Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface ICityRepositoryCustom<TEntity>
{
    // App Specific Custom Method For City Repository. (No Security Applied On This Level For Accessing)
    
    /* Cities Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Cities. (Visible Absolutely To Everyone)
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Cities By Part Of Its' Name.
     *  - Users Can Access All Cities With Given Country ID.
     *  - Users Can Access City By Its' Alpha-3 Code.
     * 
     */
    
    
    // Asynchronous Operations.

    
    /// <summary>
    /// Method Gets All Cities Within The Given Country.
    /// </summary>
    /// <param name="countryId">Defines Country Id To Search For Cities.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public Task<IEnumerable<TEntity>> GetByCountryAsync(Guid countryId, bool noTracking = true);
}
