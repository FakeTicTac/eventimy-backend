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
/// Event Reaction Data Access Layer Repository Design Implementation.
/// </summary>
public class EventReactionRepository : BaseEntityRepository<DalAppDTO.EventReaction, DomainApp.EventReaction, AppUser, AppDbContext>, 
    IEventReactionRepository
{
    /// <summary>
    /// Data Access Layer Event Reaction Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventReactionRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new EventReactionMapper(mapper)) { }

    
    // Asynchronous Operations.
    
    
    /// <summary>
    /// Method Gets All Reactions For The Particular Event Asynchronously. 
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For Reactions.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.EventReaction>> GetAllByEventAsync(Guid eventId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.EventId.Equals(eventId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}