using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Performer Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PerformerTypeMapper : BaseMapper<PerformerType, BllAppDTO.PerformerType>
{
    /// <summary>
    /// Basic Performer Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerTypeMapper(IMapper mapper) : base(mapper) { }
}