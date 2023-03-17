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
/// Event Reaction Business Logic Layer Service Design Implementation.
/// </summary>
public class EventReactionService : BaseEntityService<BllAppDTO.EventReaction, DalAppDTO.EventReaction, IAppUnitOfWork, IEventReactionRepository>, 
    IEventReactionService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventReactionService(IAppUnitOfWork serviceUow, IEventReactionRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new EventReactionMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Reactions For The Particular Event Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For Reactions.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.EventReaction>> GetAllByEventAsync(Guid eventId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByEventAsync(eventId, noTracking)).Select(x => Mapper.Map(x))!;
}