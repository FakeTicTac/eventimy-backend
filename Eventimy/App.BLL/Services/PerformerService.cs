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
/// Performer Business Logic Layer Service Design Implementation.
/// </summary>
public class PerformerService : BaseEntityService<BllAppDTO.Performer, DalAppDTO.Performer, IAppUnitOfWork, IPerformerRepository>, 
    IPerformerService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerService(IAppUnitOfWork serviceUow, IPerformerRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new PerformerMapper(mapper)) { }

    
    // Asynchronous Operations.

    
    /// <summary>
    /// Method Gets All Performers Who Perform At Particular Event Asynchronously. 
    /// </summary>
    /// <param name="eventId">Defines Event ID For Performer Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Performer>> GetAllByEventId(Guid eventId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByEventId(eventId, noTracking)).Select(x => Mapper.Map(x))!;
}
