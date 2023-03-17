using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Subscription Business Logic Layer Service Design: Basic and Custom Subscription Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface ISubscriptionService : IEntityService<BllAppDTO.Subscription, DalAppDTO.Subscription>, 
    ISubscriptionServiceCustom<BllAppDTO.Subscription, DalAppDTO.Subscription>,
    ISubscriptionRepositoryCustom<BllAppDTO.Subscription> { }


/// <summary>
/// Subscription Business Logic Layer Service Design: Custom Subscription Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface ISubscriptionServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Subscription Are In Public Access.
     *
     * - Only Users That Are Either Sender Or Recipient Can Modify State. (Delete or Update)
     * 
     * 
     */
}