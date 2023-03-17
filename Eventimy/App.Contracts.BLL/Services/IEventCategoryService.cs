using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Event Category Business Logic Layer Service Design: Basic and Custom Event Category Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IEventCategoryService : IEntityService<BllAppDTO.EventCategory, DalAppDTO.EventCategory>,
    IEventCategoryServiceCustom<BllAppDTO.EventCategory, DalAppDTO.EventCategory>,
    IEventCategoryRepositoryCustom<BllAppDTO.EventCategory> { }


/// <summary>
/// Event Category Business Logic Layer Service Design: Custom Event Category Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IEventCategoryServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Event Categories Are In Public Access. However Only ADMIN Can Modify. (Check in Controller Layer)
     *
     */
}