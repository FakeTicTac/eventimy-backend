using AutoMapper;
using App.BLL.Mappers;
using App.Contracts.DAL;
using Base.BLL.Services;
using App.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Services;


/// <summary>
/// City Business Logic Layer Service Design Implementation. 
/// </summary>
public class CityService : BaseEntityService<BllAppDTO.City, DalAppDTO.City, IAppUnitOfWork, ICityRepository>, 
    ICityService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CityService(IAppUnitOfWork serviceUow, ICityRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new CityMapper(mapper)) { }

    
    // Asynchronous Operations.

    
    /// <summary>
    /// Method Gets All Cities Within The Given Country.
    /// </summary>
    /// <param name="countryId">Defines Country Id To Search For Cities Asynchronously.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.City>> GetByCountryAsync(Guid countryId, bool noTracking = true) =>
        (await ServiceRepository.GetByCountryAsync(countryId, noTracking)).Select(x => Mapper.Map(x))!;
}
