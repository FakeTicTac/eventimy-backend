using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Event Media File Business Logic Layer Service Design: Basic and Custom Event Media File Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IEventMediaFileService : IEntityService<BllAppDTO.EventMediaFile, DalAppDTO.EventMediaFile>,
    IEventMediaFileServiceCustom<BllAppDTO.EventMediaFile, DalAppDTO.EventMediaFile>,
    IEventMediaFileRepositoryCustom<BllAppDTO.EventMediaFile> { }


/// <summary>
/// Event Media File Business Logic Layer Service Design: Custom Event Media File Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IEventMediaFileServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}