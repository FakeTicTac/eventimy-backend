using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Reaction Type Business Logic Layer Service Design: Basic and Custom Reaction Type Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IReactionTypeService : IEntityService<BllAppDTO.ReactionType, DalAppDTO.ReactionType>, 
    IReactionTypeServiceCustom<BllAppDTO.ReactionType, DalAppDTO.ReactionType>,
    IReactionTypeRepositoryCustom<BllAppDTO.ReactionType> { }


/// <summary>
/// Reaction Type Business Logic Layer Service Design: Custom Reaction Type Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IReactionTypeServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
    
    /* Reaction Types Are In Public Access. However Only ADMIN Can Modify. (Check in Controller Layer)
     *
     */
}