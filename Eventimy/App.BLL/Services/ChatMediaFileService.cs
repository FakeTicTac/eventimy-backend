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
/// Chat Media File Business Logic Layer Service Design Implementation.
/// </summary>
public class ChatMediaFileService : BaseEntityService<BllAppDTO.ChatMediaFile, DalAppDTO.ChatMediaFile, IAppUnitOfWork, IChatMediaFileRepository>, 
    IChatMediaFileService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMediaFileService(IAppUnitOfWork serviceUow, IChatMediaFileRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new ChatMediaFileMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatMediaFile>> GetAllByChatIdAsync(Guid chatId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatIdAsync(chatId, noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat ID And Media File Type ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Media Files.</param>
    /// <param name="mediaFileTypeId">Defines Media File Type ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatMediaFile>> GetAllByChatAndFileTypeIdAsync(Guid chatId, Guid mediaFileTypeId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatAndFileTypeIdAsync(chatId, mediaFileTypeId, noTracking))
            .Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat Message ID Asynchronously.
    /// </summary>
    /// <param name="chatMessageId">Defines Chat Message ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.ChatMediaFile>> GetAllByChatMessageIdAsync(Guid chatMessageId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByChatMessageIdAsync(chatMessageId, noTracking)).Select(x => Mapper.Map(x))!;
}
