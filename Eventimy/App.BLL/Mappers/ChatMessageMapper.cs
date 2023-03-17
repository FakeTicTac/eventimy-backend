using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Chat Message Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMessageMapper : BaseMapper<BllAppDTO.ChatMessage, DalAppDTO.ChatMessage>
{
    /// <summary>
    /// Basic Chat Message Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMessageMapper(IMapper mapper) : base(mapper) { }
}