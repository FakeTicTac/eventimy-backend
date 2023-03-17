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
/// Event Category Business Logic Layer Service Design Implementation.
/// </summary>
public class EventCategoryService : BaseEntityService<BllAppDTO.EventCategory, DalAppDTO.EventCategory, IAppUnitOfWork, IEventCategoryRepository>, 
    IEventCategoryService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work.  
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventCategoryService(IAppUnitOfWork serviceUow, IEventCategoryRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new EventCategoryMapper(mapper)) { }

    
    // Asynchronous Operations.

    
    /// <summary>
    /// Method Gets All Event Categories of Parent Event Category Asynchronously.
    /// </summary>
    /// <param name="parentEventCategoryId">Defines Parent Event Category ID.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.EventCategory>> GetAllByParentEventCategoryAsync(Guid parentEventCategoryId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByParentEventCategoryAsync(parentEventCategoryId, noTracking))
        .Select(x => Mapper.Map(x))!;
}