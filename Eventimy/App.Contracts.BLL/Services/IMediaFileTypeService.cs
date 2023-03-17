using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Media File Type Business Logic Layer Service Design: Basic and Custom Media File Type Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IMediaFileTypeService : IEntityService<BllAppDTO.MediaFileType, DalAppDTO.MediaFileType>, 
    IMediaFileTypeServiceCustom<BllAppDTO.MediaFileType, DalAppDTO.MediaFileType>,
    IMediaFileTypeRepositoryCustom<BllAppDTO.MediaFileType> { }


/// <summary>
/// Media File Type Business Logic Layer Service Design: Custom Media File Type Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IMediaFileTypeServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Media File Types Are In Public Access. However Only ADMIN Can Modify. (Check in Controller Layer)
     *
     */
}