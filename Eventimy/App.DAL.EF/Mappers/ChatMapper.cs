using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Chat Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMapper : BaseMapper<DalAppDTO.Chat, DomainApp.Chat>
{
    /// <summary>
    /// Basic Chat Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMapper(IMapper mapper) : base(mapper) { }
}