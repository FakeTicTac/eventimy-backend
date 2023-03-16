using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Country Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class CountryMapper : BaseMapper<DalAppDTO.Country, DomainApp.Country>
{
    /// <summary>
    /// Basic Country Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CountryMapper(IMapper mapper) : base(mapper) { }
}