using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Performer Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PerformerTypeMapper : BaseMapper<DalAppDTO.PerformerType, DomainApp.PerformerType>
{
    /// <summary>
    /// Basic Performer Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerTypeMapper(IMapper mapper) : base(mapper) { }
}