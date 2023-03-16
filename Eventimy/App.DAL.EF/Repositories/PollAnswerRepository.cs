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
/// Poll Answer Data Access Layer Repository Design Implementation. 
/// </summary>
public class PollAnswerRepository : BaseEntityRepository<DalAppDTO.PollAnswer, DomainApp.PollAnswer, AppUser, AppDbContext>, 
    IPollAnswerRepository
{
    
    /// <summary>
    /// Data Access Layer Poll Answer Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollAnswerRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new PollAnswerMapper(mapper)) { }

    
    // Asynchronous Operations.
    

    /// <summary>
    /// Method Gets All Poll Answers By Given Poll Option Asynchronously.
    /// </summary>
    /// <param name="pollOptionId">Defines Poll Option ID To Search For Poll Answers.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.PollAnswer>> GetAllByPollOptionIdAsync(Guid pollOptionId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.PollOptionId.Equals(pollOptionId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}