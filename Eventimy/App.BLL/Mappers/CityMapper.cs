using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// City Mapping Profile Definition: Basic Implementation + Custom Implementation. 
/// </summary>
public class CityMapper : BaseMapper<BllAppDTO.City, DalAppDTO.City>
{
    /// <summary>
    /// Basic City Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CityMapper(IMapper mapper) : base(mapper) { }
}