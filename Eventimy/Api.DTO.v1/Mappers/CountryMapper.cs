using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Country Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class CountryMapper : BaseMapper<Country, BllAppDTO.Country>
{
    /// <summary>
    /// Basic Country Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CountryMapper(IMapper mapper) : base(mapper) { }
}