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
/// Chat Data Access Layer Repository Design Implementation.
/// </summary>
public class ChatRepository : BaseEntityRepository<DalAppDTO.Chat, DomainApp.Chat, AppUser, AppDbContext>, 
    IChatRepository
{
    
    /// <summary>
    /// Data Access Layer Chat Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new ChatMapper(mapper)) { }
    
    
    // Asynchronous Operations.


    /// <summary>
    /// Method Get All Chats From The Database Asynchronously.
    /// </summary>
    /// <param name="userId">Defines Chat Demanding User ID Value.</param>
    /// <param name="noTracking">Defines Tracking Option.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public override async Task<IEnumerable<DalAppDTO.Chat>> GetAllAsync(object? userId = null, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
                                                    .Include(y => y.ChatParticipants);

        return (await query.Where(x => x.ChatParticipants!.Any(y => y.AppUserId.Equals(userId))).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets Chats Of The Given Event ID Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Entity.</returns>
    public async Task<DalAppDTO.Chat?> GetChatByEventIdAsync(Guid eventId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return Mapper.Map(await query.FirstOrDefaultAsync(x => x.EventId.Equals(eventId)));
    }

    /// <summary>
    /// Method Creates Query to Connect with the Database. Includes List Of Participants.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">>Tracking Option Definition.</param>
    /// <returns>IQueryable of TEntity. (Query)</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    protected override IQueryable<DomainApp.Chat> CreateQuery(object? userId = null, bool noTracking = true) =>
        base.CreateQuery(userId, noTracking).Include(x => x.ChatParticipants);
}
