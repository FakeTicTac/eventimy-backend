using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Event Category Mapping Profile Definition: Basic Implementation + Custom Implementation. 
/// </summary>
public class EventCategoryMapper : BaseMapper<DalAppDTO.EventCategory, DomainApp.EventCategory>
{
    /// <summary>
    /// Basic Event Category Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventCategoryMapper(IMapper mapper) : base(mapper) { }
}