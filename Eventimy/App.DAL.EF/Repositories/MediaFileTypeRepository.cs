using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Media File Type Data Access Layer Repository Design Implementation.  
/// </summary>
public class MediaFileTypeRepository : BaseEntityRepository<DalAppDTO.MediaFileType, DomainApp.MediaFileType, AppUser, AppDbContext>, 
    IMediaFileTypeRepository
{
    
    /// <summary>
    /// Data Access Layer Media File Type Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public MediaFileTypeRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new MediaFileTypeMapper(mapper)) { }
}