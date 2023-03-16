using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Performer Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PerformerMapper : BaseMapper<DalAppDTO.Performer, DomainApp.Performer>
{
    /// <summary>
    /// Basic Performer Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerMapper(IMapper mapper) : base(mapper) { }
}