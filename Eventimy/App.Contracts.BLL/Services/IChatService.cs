using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Chat Business Logic Layer Service Design: Basic and Custom Chat Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IChatService : IEntityService<BllAppDTO.Chat, DalAppDTO.Chat>, 
    IChatServiceCustom<BllAppDTO.Chat, DalAppDTO.Chat>,
    IChatRepositoryCustom<BllAppDTO.Chat> { }


/// <summary>
/// Chat Message Business Logic Layer Service Design: Custom Chat Message Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IChatServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}