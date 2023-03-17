using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Reaction Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ReactionTypeMapper : BaseMapper<BllAppDTO.ReactionType, DalAppDTO.ReactionType>
{
    /// <summary>
    /// Basic Reaction Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ReactionTypeMapper(IMapper mapper) : base(mapper) { }
}