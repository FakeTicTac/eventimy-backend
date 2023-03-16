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
/// Poll Option Data Access Layer Repository Design Implementation.
/// </summary>
public class PollOptionRepository : BaseEntityRepository<DalAppDTO.PollOption, DomainApp.PollOption, AppUser, AppDbContext>, 
    IPollOptionRepository
{
    /// <summary>
    /// Data Access Layer Poll Option Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollOptionRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new PollOptionMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Poll Options By Given Chat Poll Asynchronously.
    /// </summary>
    /// <param name="chatPollId">Defines Chat Poll ID To Search For Poll Options.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.PollOption>> GetAllByChatPollIdAsync(Guid chatPollId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ChatPollId.Equals(chatPollId)).ToListAsync()).Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Creates Query to Connect with the Database. Includes List Of Poll Option Answers.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">>Tracking Option Definition.</param>
    /// <returns>IQueryable of TEntity. (Query)</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    protected override IQueryable<DomainApp.PollOption> CreateQuery(object? userId = null, bool noTracking = true) => 
        base.CreateQuery(userId, noTracking).Include(x => x.PollAnswers);
}
