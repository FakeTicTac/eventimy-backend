using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Chat Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMapper : BaseMapper<Chat, BllAppDTO.Chat>
{
    /// <summary>
    /// Basic Chat Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMapper(IMapper mapper) : base(mapper) { }
}