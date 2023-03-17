using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Poll Answer Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PollAnswerMapper : BaseMapper<BllAppDTO.PollAnswer, DalAppDTO.PollAnswer>
{
    /// <summary>
    /// Basic Poll Answer Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollAnswerMapper(IMapper mapper) : base(mapper) { }
}