using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Poll Answer Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PollAnswerMapper : BaseMapper<DalAppDTO.PollAnswer, DomainApp.PollAnswer>
{
    /// <summary>
    /// Basic Poll Answer Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollAnswerMapper(IMapper mapper) : base(mapper) { }
}