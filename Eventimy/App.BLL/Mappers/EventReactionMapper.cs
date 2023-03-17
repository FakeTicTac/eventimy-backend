using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Event Reaction Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class EventReactionMapper : BaseMapper<BllAppDTO.EventReaction, DalAppDTO.EventReaction>
{
    /// <summary>
    /// Basic Event Reaction Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventReactionMapper(IMapper mapper) : base(mapper) { }
}