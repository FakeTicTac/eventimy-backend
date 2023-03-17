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
/// Event Media File Business Logic Layer Service Design Implementation.
/// </summary>
public class EventMediaFileService : BaseEntityService<BllAppDTO.EventMediaFile, DalAppDTO.EventMediaFile, IAppUnitOfWork, IEventMediaFileRepository>, 
    IEventMediaFileService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventMediaFileService(IAppUnitOfWork serviceUow, IEventMediaFileRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new EventMediaFileMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Event Media Files For The Particular Event Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For  Event Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.EventMediaFile>> GetAllByEventIdAsync(Guid eventId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByEventIdAsync(eventId, noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets All Event Media Files For The Particular Event of Given Type Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For  Event Media Files.</param>
    /// <param name="mediaFileTypeId">Defines Media File Type ID.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.EventMediaFile>> GetAllByEventAndFileTypeIdAsync(Guid eventId, Guid mediaFileTypeId, bool noTracking = true) => 
        (await ServiceRepository.GetAllByEventAndFileTypeIdAsync(eventId, mediaFileTypeId, noTracking))
            .Select(x => Mapper.Map(x))!;
}
