using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Event Category Mapping Profile Definition: Basic Implementation + Custom Implementation. 
/// </summary>
public class EventCategoryMapper : BaseMapper<BllAppDTO.EventCategory, DalAppDTO.EventCategory>
{
    /// <summary>
    /// Basic Event Category Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventCategoryMapper(IMapper mapper) : base(mapper) { }
}