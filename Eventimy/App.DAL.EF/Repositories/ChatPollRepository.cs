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
/// Chat Poll Data Access Layer Repository Design Implementation.
/// </summary>
public class ChatPollRepository : BaseEntityRepository<DalAppDTO.ChatPoll, DomainApp.ChatPoll, AppUser, AppDbContext>,
    IChatPollRepository
{

    /// <summary>
    /// Data Access Layer Chat Poll Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatPollRepository(AppDbContext dbContext, IMapper mapper) :
        base(dbContext, new ChatPollMapper(mapper)) { }


    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Polls By Given Chat Value Asynchronously.
    /// </summary>
    /// <param name="chatId">Defines Chat ID Value To Search For Polls.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.ChatPoll>> GetAllByChatId(Guid chatId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatId.Equals(chatId)).ToListAsync()).Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Creates Query to Connect with the Database. Includes List Of Poll Options.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">>Tracking Option Definition.</param>
    /// <returns>IQueryable of TEntity. (Query)</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    protected override IQueryable<DomainApp.ChatPoll> CreateQuery(object? userId = null, bool noTracking = true) =>
        base.CreateQuery(userId, noTracking).Include(x => x.PollOptions);
}