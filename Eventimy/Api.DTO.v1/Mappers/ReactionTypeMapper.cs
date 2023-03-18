using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Reaction Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ReactionTypeMapper : BaseMapper<ReactionType, BllAppDTO.ReactionType>
{
    /// <summary>
    /// Basic Reaction Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ReactionTypeMapper(IMapper mapper) : base(mapper) { }
}