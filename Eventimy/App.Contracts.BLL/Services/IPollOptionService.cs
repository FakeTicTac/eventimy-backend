using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Poll Option Business Logic Layer Service Design: Basic and Custom Poll Option Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IPollOptionService : IEntityService<BllAppDTO.PollOption, DalAppDTO.PollOption>,
    IPollOptionServiceCustom<BllAppDTO.PollOption, DalAppDTO.PollOption>,
    IPollOptionRepositoryCustom<BllAppDTO.PollOption> { }


/// <summary>
/// Poll Option Business Logic Layer Service Design: Custom Poll Option Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IPollOptionServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}