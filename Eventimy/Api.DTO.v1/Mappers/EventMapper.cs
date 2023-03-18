using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Event Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class EventMapper : BaseMapper<Event, BllAppDTO.Event>
{
    /// <summary>
    /// Basic Event Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventMapper(IMapper mapper) : base(mapper) { }
}