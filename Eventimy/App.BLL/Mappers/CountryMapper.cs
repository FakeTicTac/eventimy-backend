using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Country Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class CountryMapper : BaseMapper<BllAppDTO.Country, DalAppDTO.Country>
{
    /// <summary>
    /// Basic Country Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CountryMapper(IMapper mapper) : base(mapper) { }
}