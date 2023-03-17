using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Country Business Logic Layer Service Design: Basic and Custom Country Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface ICountryService : IEntityService<BllAppDTO.Country, DalAppDTO.Country>, 
    ICountryServiceCustom<BllAppDTO.Country, DalAppDTO.Country>,
    ICountryRepositoryCustom<BllAppDTO.Country>
{
    
    // App Specific Custom Method For Country Service. (Partial Security Applied On This Level)
    
}

/// <summary>
/// Country Business Logic Layer Service Design: Custom Country Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface ICountryServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Countries Are In Public Access. However Only ADMIN Can Modify. (Check in Controller Layer)
     *
     */
}