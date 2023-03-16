using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Poll Option Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PollOptionMapper : BaseMapper<DalAppDTO.PollOption, DomainApp.PollOption>
{
    /// <summary>
    /// Basic Poll Option Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollOptionMapper(IMapper mapper) : base(mapper) { }
}