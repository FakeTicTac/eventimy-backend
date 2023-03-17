using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Performer Business Logic Layer Service Design: Basic and Custom Performer Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IPerformerService : IEntityService<BllAppDTO.Performer, DalAppDTO.Performer>, 
    IPerformerServiceCustom<BllAppDTO.Performer, DalAppDTO.Performer>,
    IPerformerRepositoryCustom<BllAppDTO.Performer> { }


/// <summary>
/// Performer Business Logic Layer Service Design: Custom Performer Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IPerformerServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}