using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// City Mapping Profile Definition: Basic Implementation + Custom Implementation. 
/// </summary>
public class CityMapper : BaseMapper<City, BllAppDTO.City>
{
    /// <summary>
    /// Basic City Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CityMapper(IMapper mapper) : base(mapper) { }
}