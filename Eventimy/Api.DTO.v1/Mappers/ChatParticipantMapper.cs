using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Chat Participant Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatParticipantMapper : BaseMapper<ChatParticipant, BllAppDTO.ChatParticipant>
{
    /// <summary>
    /// Basic Chat Participant Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatParticipantMapper(IMapper mapper) : base(mapper) { }
}