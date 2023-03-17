using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// User In Event Business Logic Layer Service Design: Basic and Custom User In Event Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IUserInEventService : IEntityService<BllAppDTO.UserInEvent, DalAppDTO.UserInEvent>, 
    IUserInEventServiceCustom<BllAppDTO.UserInEvent, DalAppDTO.UserInEvent>,
    IUserInEventRepositoryCustom<BllAppDTO.UserInEvent> { }


/// <summary>
/// User In Event Business Logic Layer Service Design: Custom User In Event Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IUserInEventServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method ForUser In Event Service. (Partial Security Applied On This Level)
}