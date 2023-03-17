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
/// Event Business Logic Layer Service Design Implementation.
/// </summary>
public class EventService : BaseEntityService<BllAppDTO.Event, DalAppDTO.Event, IAppUnitOfWork, IEventRepository>, 
    IEventService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventService(IAppUnitOfWork serviceUow, IEventRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new EventMapper(mapper)) { }
}