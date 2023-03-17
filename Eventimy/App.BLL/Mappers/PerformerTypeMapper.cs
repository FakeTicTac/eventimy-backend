using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Performer Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PerformerTypeMapper : BaseMapper<BllAppDTO.PerformerType, DalAppDTO.PerformerType>
{
    /// <summary>
    /// Basic Performer Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerTypeMapper(IMapper mapper) : base(mapper) { }
}