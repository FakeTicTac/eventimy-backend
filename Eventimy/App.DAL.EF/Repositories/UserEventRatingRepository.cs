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
/// User In Collection Data Access Layer Repository Design Implementation. 
/// </summary>
public class UserEventRatingRepository : BaseEntityRepository<DalAppDTO.UserEventRating, DomainApp.UserEventRating, AppUser, AppDbContext>, 
    IUserEventRatingRepository
{
    
    /// <summary>
    /// Data Access Layer User In Collection Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserEventRatingRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new UserEventRatingMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Event Ratings of Given Event.
    /// </summary>
    /// <param name="eventId">Defines Event ID Value To Search For Event Ratings.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.UserEventRating>> GetAllByEventIdAsync(Guid eventId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.EventId.Equals(eventId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}