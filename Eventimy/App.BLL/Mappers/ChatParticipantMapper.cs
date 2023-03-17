using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Chat Participant Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatParticipantMapper : BaseMapper<BllAppDTO.ChatParticipant, DalAppDTO.ChatParticipant>
{
    /// <summary>
    /// Basic Chat Participant Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatParticipantMapper(IMapper mapper) : base(mapper) { }
}