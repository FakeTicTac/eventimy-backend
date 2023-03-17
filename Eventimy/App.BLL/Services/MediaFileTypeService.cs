using AutoMapper;
using App.BLL.Mappers;
using App.Contracts.DAL;
using Base.BLL.Services;
using App.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Services;


/// <summary>
/// Media File Type Business Logic Layer Service Design Implementation.
/// </summary>
public class MediaFileTypeService : BaseEntityService<BllAppDTO.MediaFileType, DalAppDTO.MediaFileType, IAppUnitOfWork, IMediaFileTypeRepository>, 
    IMediaFileTypeService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work.  
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public MediaFileTypeService(IAppUnitOfWork serviceUow, IMediaFileTypeRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new MediaFileTypeMapper(mapper)) { }
}