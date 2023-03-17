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
/// Chat Message Business Logic Layer Service Design Implementation.
/// </summary>
public class ChatMessageService : BaseEntityService<BllAppDTO.ChatMessage, DalAppDTO.ChatMessage, IAppUnitOfWork, IChatMessageRepository>, 
    IChatMessageService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMessageService(IAppUnitOfWork serviceUow, IChatMessageRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new ChatMessageMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatMessage>> GetAllByChatIdAsync(Guid chatId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatIdAsync(chatId, noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID and Its' Partial Content Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="partialContent">Defines Part Of Chat Message Content For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatMessage>> GetAllByChatIdAndPartialContentAsync(Guid chatId, string partialContent, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatIdAndPartialContentAsync(chatId, partialContent, noTracking))
            .Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID and Its' Participant ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="participantId">Defines Participant ID To Search For Chat Messages.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatMessage>> GetAllByChatAndParticipantIdAsync(Guid chatId, Guid participantId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatAndParticipantIdAsync(chatId, participantId, noTracking))
            .Select(x => Mapper.Map(x))!;
}
