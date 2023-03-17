using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Chat Message Business Logic Layer Service Design: Basic and Custom Chat Message Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IChatMessageService : IEntityService<BllAppDTO.ChatMessage, DalAppDTO.ChatMessage>, 
    IChatMessageServiceCustom<BllAppDTO.ChatMessage, DalAppDTO.ChatMessage>,
    IChatMessageRepositoryCustom<BllAppDTO.ChatMessage> { }


/// <summary>
/// Chat Message Business Logic Layer Service Design: Custom Chat Message Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IChatMessageServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}