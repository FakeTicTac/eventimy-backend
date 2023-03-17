using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Chat Media File Business Logic Layer Service Design: Basic and Custom Chat Media File Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IChatMediaFileService : IEntityService<BllAppDTO.ChatMediaFile, DalAppDTO.ChatMediaFile>, 
    IChatMediaFileServiceCustom<BllAppDTO.ChatMediaFile, DalAppDTO.ChatMediaFile>,
    IChatMediaFileRepositoryCustom<BllAppDTO.ChatMediaFile> { }


/// <summary>
/// Chat Media File Business Logic Layer Service Design: Custom Chat Media File Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IChatMediaFileServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Media File Service. (Partial Security Applied On This Level)
}