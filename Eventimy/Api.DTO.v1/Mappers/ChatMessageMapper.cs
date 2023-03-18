using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Chat Message Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMessageMapper : BaseMapper<ChatMessage, BllAppDTO.ChatMessage>
{
    /// <summary>
    /// Basic Chat Message Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMessageMapper(IMapper mapper) : base(mapper) { }
}