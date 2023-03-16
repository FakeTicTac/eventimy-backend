using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Chat Message Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMessageMapper : BaseMapper<DalAppDTO.ChatMessage, DomainApp.ChatMessage>
{
    /// <summary>
    /// Basic Chat Message Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMessageMapper(IMapper mapper) : base(mapper) { }
}