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
/// Performer Data Access Layer Repository Design Implementation. 
/// </summary>
public class PerformerRepository : BaseEntityRepository<DalAppDTO.Performer, DomainApp.Performer, AppUser, AppDbContext>, 
    IPerformerRepository
{
    /// <summary>
    /// Data Access Layer Performer Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new PerformerMapper(mapper)) { }

    
    // Asynchronous Operations.
    
    
    /// <summary>
    /// Method Gets All Performers Who Perform At Particular Event Asynchronously. 
    /// </summary>
    /// <param name="eventId">Defines Event ID For Performer Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Performer>> GetAllByEventId(Guid eventId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.EventId.Equals(eventId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}
