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
/// Chat Poll Business Logic Layer Service Design Implementation.
/// </summary>
public class ChatPollService : BaseEntityService<BllAppDTO.ChatPoll, DalAppDTO.ChatPoll, IAppUnitOfWork, IChatPollRepository>, 
    IChatPollService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatPollService(IAppUnitOfWork serviceUow, IChatPollRepository serviceRepository, IMapper mapper) :
        base(serviceUow, serviceRepository, new ChatPollMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Polls By Given Chat Value Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID Value To Search For Polls.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatPoll>> GetAllByChatId(Guid chatId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatId(chatId, noTracking)).Select(x => Mapper.Map(x))!;
}
