using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Reaction Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ReactionTypeMapper : BaseMapper<DalAppDTO.ReactionType, DomainApp.ReactionType>
{
    /// <summary>
    /// Basic Reaction Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ReactionTypeMapper(IMapper mapper) : base(mapper) { }
}