using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// City Mapping Profile Definition: Basic Implementation + Custom Implementation. 
/// </summary>
public class CityMapper : BaseMapper<DalAppDTO.City, DomainApp.City>
{
    /// <summary>
    /// Basic City Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CityMapper(IMapper mapper) : base(mapper) { }
}