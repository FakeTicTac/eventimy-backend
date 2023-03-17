using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// User Event Rating Business Logic Layer Service Design: Basic and Custom User Event Rating Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IUserEventRatingService : IEntityService<BllAppDTO.UserEventRating, DalAppDTO.UserEventRating>, 
    IUserEventRatingServiceCustom<BllAppDTO.UserEventRating, DalAppDTO.UserEventRating>,
    IUserEventRatingRepositoryCustom<BllAppDTO.UserEventRating> { }


/// <summary>
/// User Event Rating Business Logic Layer Service Design: Custom User Event Rating Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IUserEventRatingServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For User Event Rating Service. (Partial Security Applied On This Level)
}