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
/// Poll Option Business Logic Layer Service Design Implementation.
/// </summary>
public class PollOptionService : BaseEntityService<BllAppDTO.PollOption, DalAppDTO.PollOption, IAppUnitOfWork, IPollOptionRepository>, 
    IPollOptionService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollOptionService(IAppUnitOfWork serviceUow, IPollOptionRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new PollOptionMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Poll Options By Given Chat Poll Asynchronously.
    /// </summary>
    /// <param name="chatPollId">Defines Chat Poll ID To Search For Poll Options.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.PollOption>> GetAllByChatPollIdAsync(Guid chatPollId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatPollIdAsync(chatPollId, noTracking)).Select(x => Mapper.Map(x))!;
}