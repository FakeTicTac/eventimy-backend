using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Chat Poll Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatPollMapper : BaseMapper<DalAppDTO.ChatPoll, DomainApp.ChatPoll>
{
    /// <summary>
    /// Basic Chat Poll Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatPollMapper(IMapper mapper) : base(mapper) { }
}