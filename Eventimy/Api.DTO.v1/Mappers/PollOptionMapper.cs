using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Poll Option Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PollOptionMapper : BaseMapper<PollOption, BllAppDTO.PollOption>
{
    /// <summary>
    /// Basic Poll Option Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollOptionMapper(IMapper mapper) : base(mapper) { }
}