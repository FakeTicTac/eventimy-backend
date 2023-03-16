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
/// Chat Message Data Access Layer Repository Design Implementation.
/// </summary>
public class ChatMessageRepository : BaseEntityRepository<DalAppDTO.ChatMessage, DomainApp.ChatMessage , AppUser, AppDbContext>, 
    IChatMessageRepository
{
    
    /// <summary>
    /// Data Access Layer Chat Message Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMessageRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new ChatMessageMapper(mapper)) { }

    
    // Asynchronous Operations.
    
    
    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatMessage>> GetAllByChatIdAsync(Guid chatId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatId.Equals(chatId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID and Its' Partial Content Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="partialContent">Defines Part Of Chat Message Content For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatMessage>> GetAllByChatIdAndPartialContentAsync(Guid chatId, string partialContent, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => 
            x.ChatId.Equals(chatId) && x.Content!.ToUpper().Contains(partialContent.ToUpper())).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets Chat Massages Of The Given Chat ID and Its' Participant ID Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID To Search For Chat Messages.</param>
    /// <param name="participantId">Defines Participant ID To Search For Chat Messages.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatMessage>> GetAllByChatAndParticipantIdAsync(Guid chatId, Guid participantId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatId.Equals(chatId) && x.ChatParticipantId.Equals(participantId))
            .ToListAsync()).Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Creates Query to Connect with the Database. Includes Lists Of Data.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">>Tracking Option Definition.</param>
    /// <returns>IQueryable of TEntity. (Query)</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    protected override IQueryable<DomainApp.ChatMessage> CreateQuery(object? userId = null, bool noTracking = true) =>
        base.CreateQuery(userId, noTracking)
            .Include(x => x.ChatMediaFiles);
}
