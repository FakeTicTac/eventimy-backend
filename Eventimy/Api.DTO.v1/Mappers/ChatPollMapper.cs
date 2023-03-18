using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Chat Poll Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatPollMapper : BaseMapper<ChatPoll, BllAppDTO.ChatPoll>
{
    /// <summary>
    /// Basic Chat Poll Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatPollMapper(IMapper mapper) : base(mapper) { }
}