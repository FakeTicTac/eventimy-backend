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
/// Event Media File Data Access Layer Repository Design Implementation. 
/// </summary>
public class EventMediaFileRepository : BaseEntityRepository<DalAppDTO.EventMediaFile, DomainApp.EventMediaFile, AppUser, AppDbContext>, 
    IEventMediaFileRepository
{
    /// <summary>
    /// Data Access Layer Event Media File Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventMediaFileRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new EventMediaFileMapper(mapper)) { }

    
    // Asynchronous Operations.
    
    
    /// <summary>
    /// Method Gets All Event Media Files For The Particular Event Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For  Event Media Files.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.EventMediaFile>> GetAllByEventIdAsync(Guid eventId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.EventId.Equals(eventId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets All Event Media Files For The Particular Event of Given Type Asynchronously.
    /// </summary>
    /// <param name="eventId">Defines Event ID To Search For  Event Media Files.</param>
    /// <param name="mediaFileTypeId">Defines Media File Type ID.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.EventMediaFile>> GetAllByEventAndFileTypeIdAsync(Guid eventId, Guid mediaFileTypeId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.EventId.Equals(eventId) && x.MediaFileTypeId.Equals(mediaFileTypeId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}
