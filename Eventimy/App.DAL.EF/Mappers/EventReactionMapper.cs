using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Event Reaction Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class EventReactionMapper : BaseMapper<DalAppDTO.EventReaction, DomainApp.EventReaction>
{
    /// <summary>
    /// Basic Event Reaction Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventReactionMapper(IMapper mapper) : base(mapper) { }
}