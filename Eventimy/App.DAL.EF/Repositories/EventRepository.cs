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
/// Event Data Access Layer Repository Design Implementation.
/// </summary>
public class EventRepository : BaseEntityRepository<DalAppDTO.Event, DomainApp.Event, AppUser, AppDbContext>, 
    IEventRepository
{
    
    /// <summary>
    /// Data Access Layer Event Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new EventMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Get All User Achievements From The Database Asynchronously.
    /// </summary>
    /// <param name="userId">Defines User Achievement Demanding User ID Value.</param>
    /// <param name="noTracking">Defines Tracking Option.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public override async Task<IEnumerable<DalAppDTO.Event>> GetAllAsync(object? userId = null, bool noTracking = true)
    {
        var query = CreateQuery(noTracking).Include(x => x.UserInEvents);

        return (await query
            .Where(x => !x.IsPrivate || x.AppUserId.Equals(userId) || x.UserInEvents!.Any(y => y.AppUserId.Equals(userId)))
            .ToListAsync()).Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Creates Query to Connect with the Database. Includes Lists Into Event.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">>Tracking Option Definition.</param>
    /// <returns>IQueryable of TEntity. (Query)</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    protected override IQueryable<DomainApp.Event> CreateQuery(object? userId = null, bool noTracking = true) =>
        base.CreateQuery(userId, noTracking)
            .Include(x => x.ChildrenEvents)
            .Include(x => x.Performers)
            .Include(x => x.EventReactions)
            .Include(x => x.Chats);
}
