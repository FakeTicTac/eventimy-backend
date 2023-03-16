using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Chat Media File Data Access Layer Repository Design Implementation. 
/// </summary>
public class ChatMediaFileRepository : BaseEntityRepository<DalAppDTO.ChatMediaFile, DomainApp.ChatMediaFile, AppUser, AppDbContext>, 
    IChatMediaFileRepository
{
    
    /// <summary>
    /// Data Access Layer Chat Media File Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Defines Mapper Connection.</param>
    public ChatMediaFileRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new ChatMediaFileMapper(mapper)) { }

    
    // Asynchronous Operations.
    
    
    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatMediaFile>> GetAllByChatIdAsync(Guid chatId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatId.Equals(chatId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat ID And Media File Type ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Media Files.</param>
    /// <param name="mediaFileTypeId">Defines Media File Type ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatMediaFile>> GetAllByChatAndFileTypeIdAsync(Guid chatId, Guid mediaFileTypeId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatId.Equals(chatId) && x.MediaFileTypeId.Equals(mediaFileTypeId))
            .ToListAsync()).Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets Chat Media Files Of The Given Chat Message ID Asynchronously.
    /// </summary>
    /// <param name="chatMessageId">Defines Chat Message ID To Search For Chat Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatMediaFile>> GetAllByChatMessageIdAsync(Guid chatMessageId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatMessageId.Equals(chatMessageId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}
