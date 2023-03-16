using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Chat Participant Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatParticipantMapper : BaseMapper<DalAppDTO.ChatParticipant, DomainApp.ChatParticipant>
{
    /// <summary>
    /// Basic Chat Participant Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatParticipantMapper(IMapper mapper) : base(mapper) { }
}