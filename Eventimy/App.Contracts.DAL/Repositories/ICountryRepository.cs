using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Country Data Access Layer Repository Design: Basic and Custom Country Repository Methods. 
/// </summary>
public interface ICountryRepository : IEntityRepository<Country>, ICountryRepositoryCustom<Country> { }


/// <summary>
/// Country Data Access Layer Repository Design: Custom Country Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface ICountryRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Country Repository. (No Security Applied On This Level For Accessing)
    
    /* Countries Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Countries. (Visible Absolutely To Everyone)
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Countries With Part Of Its' Name.
     *  - Users Can Access Country By Its' Alpha-3 Code.
     * 
     */
}
