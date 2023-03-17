using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Chat Poll Business Logic Layer Service Design: Basic and Custom Chat Poll Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IChatPollService : IEntityService<BllAppDTO.ChatPoll, DalAppDTO.ChatPoll>, 
    IChatPollServiceCustom<BllAppDTO.ChatPoll, DalAppDTO.ChatPoll>,
    IChatPollRepositoryCustom<BllAppDTO.ChatPoll> { }


/// <summary>
/// Chat Poll Business Logic Layer Service Design: Custom Chat Poll Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IChatPollServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}