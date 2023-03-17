using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// City Business Logic Layer Service Design: Basic and Custom City Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface ICityService : IEntityService<BllAppDTO.City, DalAppDTO.City>,
    ICityServiceCustom<BllAppDTO.City, DalAppDTO.City>,
    ICityRepositoryCustom<BllAppDTO.City> { }


/// <summary>
/// City Business Logic Layer Service Design: Custom City Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface ICityServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Cities Are In Public Access. However Only ADMIN Can Modify. (Check in Controller Layer)
     *
     */
}