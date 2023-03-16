using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Performer Type Data Access Layer Repository Design Implementation. 
/// </summary>
public class PerformerTypeRepository : BaseEntityRepository<DalAppDTO.PerformerType, DomainApp.PerformerType, AppUser, AppDbContext>, 
    IPerformerTypeRepository
{
    
    /// <summary>
    /// Data Access Layer Performer Type Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerTypeRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new PerformerTypeMapper(mapper)) { }
}