using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Chat Participant Business Logic Layer Service Design: Basic and Custom Chat Participant Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IChatParticipantService : IEntityService<BllAppDTO.ChatParticipant, DalAppDTO.ChatParticipant>, 
    IChatParticipantServiceCustom<BllAppDTO.ChatParticipant, DalAppDTO.ChatParticipant>,
    IChatParticipantRepositoryCustom<BllAppDTO.ChatParticipant> { }


/// <summary>
/// Chat Participant Business Logic Layer Service Design: Custom Chat Participant Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IChatParticipantServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}