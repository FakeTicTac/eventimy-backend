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
/// User In Event Business Logic Layer Service Design Implementation.
/// </summary>
public class UserInEventService : BaseEntityService<BllAppDTO.UserInEvent, DalAppDTO.UserInEvent, IAppUnitOfWork, IUserInEventRepository>, 
    IUserInEventService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserInEventService(IAppUnitOfWork serviceUow, IUserInEventRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new UserInEventMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All User In Event By Given Event Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID Value To Search For Visible To Users.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.UserInEvent>> GetAllByEventIdAsync(Guid eventId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByEventIdAsync(eventId, noTracking)).Select(x => Mapper.Map(x))!;
}