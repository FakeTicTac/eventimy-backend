using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Event Category Mapping Profile Definition: Basic Implementation + Custom Implementation. 
/// </summary>
public class EventCategoryMapper : BaseMapper<EventCategory, BllAppDTO.EventCategory>
{
    /// <summary>
    /// Basic Event Category Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventCategoryMapper(IMapper mapper) : base(mapper) { }
}