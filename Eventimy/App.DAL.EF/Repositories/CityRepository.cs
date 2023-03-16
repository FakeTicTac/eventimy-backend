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
/// City Data Access Layer Repository Design Implementation. 
/// </summary>
public class CityRepository : BaseEntityRepository<DalAppDTO.City, DomainApp.City, AppUser, AppDbContext>, 
    ICityRepository
{
    /// <summary>
    /// Data Access Layer City Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CityRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new CityMapper(mapper)) { }

    
    // Asynchronous Operations.

    
    /// <summary>
    /// Method Gets All Cities Within The Given Country Asynchronously.
    /// </summary>
    /// <param name="countryId">Defines Country Id To Search For Cities.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.City>> GetByCountryAsync(Guid countryId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.CountryId.Equals(countryId)).ToListAsync()).Select(x => Mapper.Map(x))!;
    }
}
