using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Event Reaction Business Logic Layer Service Design: Basic and Custom Event Reaction Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IEventReactionService : IEntityService<BllAppDTO.EventReaction, DalAppDTO.EventReaction>,
    IEventReactionServiceCustom<BllAppDTO.EventReaction, DalAppDTO.EventReaction>,
    IEventReactionRepositoryCustom<BllAppDTO.EventReaction> { }


/// <summary>
/// Event Reaction Business Logic Layer Service Design: Custom Event Reaction Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IEventReactionServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}