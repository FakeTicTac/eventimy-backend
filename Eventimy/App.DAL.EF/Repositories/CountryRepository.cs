using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Country Data Access Layer Repository Design Implementation.
/// </summary>
public class CountryRepository : BaseEntityRepository<DalAppDTO.Country, DomainApp.Country, AppUser, AppDbContext>, 
    ICountryRepository
{
    
    /// <summary>
    /// Data Access Layer Country Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CountryRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new CountryMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Creates Query to Connect with the Database. Includes List Of Cities.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">>Tracking Option Definition.</param>
    /// <returns>IQueryable of TEntity. (Query)</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    protected override IQueryable<DomainApp.Country> CreateQuery(object? userId = null, bool noTracking = true) =>
        base.CreateQuery(userId, noTracking).Include(x => x.Cities);
    
}
