using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Event Reaction Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class EventReactionMapper : BaseMapper<EventReaction, BllAppDTO.EventReaction>
{
    /// <summary>
    /// Basic Event Reaction Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventReactionMapper(IMapper mapper) : base(mapper) { }
}