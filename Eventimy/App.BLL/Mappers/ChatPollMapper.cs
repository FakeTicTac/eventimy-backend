using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Chat Poll Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatPollMapper : BaseMapper<BllAppDTO.ChatPoll, DalAppDTO.ChatPoll>
{
    /// <summary>
    /// Basic Chat Poll Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatPollMapper(IMapper mapper) : base(mapper) { }
}