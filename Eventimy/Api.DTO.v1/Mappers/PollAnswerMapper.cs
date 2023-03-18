using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Poll Answer Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PollAnswerMapper : BaseMapper<PollAnswer, BllAppDTO.PollAnswer>
{
    /// <summary>
    /// Basic Poll Answer Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollAnswerMapper(IMapper mapper) : base(mapper) { }
}