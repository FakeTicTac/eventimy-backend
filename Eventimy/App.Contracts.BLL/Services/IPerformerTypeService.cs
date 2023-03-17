using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Performer Type Business Logic Layer Service Design: Basic and Custom Performer Type Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IPerformerTypeService : IEntityService<BllAppDTO.PerformerType, DalAppDTO.PerformerType>, 
    IPerformerTypeServiceCustom<BllAppDTO.PerformerType, DalAppDTO.PerformerType>,
    IPerformerTypeRepositoryCustom<BllAppDTO.PerformerType> { }


/// <summary>
/// Performer Type Business Logic Layer Service Design: Custom Performer Type Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IPerformerTypeServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Performer Types Are In Public Access. However Only ADMIN Can Modify. (Check in Controller Layer)
     *
     */
}