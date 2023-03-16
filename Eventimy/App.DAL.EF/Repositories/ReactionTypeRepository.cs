using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Reaction Type Data Access Layer Repository Design Implementation.  
/// </summary>
public class ReactionTypeRepository : BaseEntityRepository<DalAppDTO.ReactionType, DomainApp.ReactionType, AppUser, AppDbContext>, 
    IReactionTypeRepository
{
    
    /// <summary>
    /// Data Access Layer Reaction Type Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ReactionTypeRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new ReactionTypeMapper(mapper)) { }
}