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
/// Event Category Data Access Layer Repository Design Implementation.
/// </summary>
public class EventCategoryRepository : BaseEntityRepository<DalAppDTO.EventCategory, DomainApp.EventCategory, AppUser, AppDbContext>, 
    IEventCategoryRepository
{
    /// <summary>
    /// Data Access Layer Event Category Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventCategoryRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new EventCategoryMapper(mapper)) { }

    
    // Asynchronous Operations.
    

    /// <summary>
    /// Method Gets All Event Categories With Particular Parent Event Category Asynchronously.
    /// </summary>
    /// <param name="parentEventCategoryId">Defines Parent Event Category ID.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.EventCategory>> GetAllByParentEventCategoryAsync(Guid parentEventCategoryId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.ParentCategoryId.Equals(parentEventCategoryId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}