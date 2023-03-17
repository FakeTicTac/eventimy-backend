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
/// Chat Business Logic Layer Service Design Implementation.
/// </summary>
public class ChatService : BaseEntityService<BllAppDTO.Chat, DalAppDTO.Chat, IAppUnitOfWork, IChatRepository>, 
    IChatService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatService(IAppUnitOfWork serviceUow, IChatRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new ChatMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets Chats Of The Given Event ID Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Entity.</returns>
    public async Task<BllAppDTO.Chat?> GetChatByEventIdAsync(Guid eventId, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.GetChatByEventIdAsync(eventId, noTracking));
}
