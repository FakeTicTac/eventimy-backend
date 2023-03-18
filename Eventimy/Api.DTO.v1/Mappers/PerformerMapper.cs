using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Performer Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PerformerMapper : BaseMapper<Performer, BllAppDTO.Performer>
{
    /// <summary>
    /// Basic Performer Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerMapper(IMapper mapper) : base(mapper) { }
}