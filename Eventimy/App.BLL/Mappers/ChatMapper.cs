using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Chat Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMapper : BaseMapper<BllAppDTO.Chat, DalAppDTO.Chat>
{
    /// <summary>
    /// Basic Chat Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMapper(IMapper mapper) : base(mapper) { }
}