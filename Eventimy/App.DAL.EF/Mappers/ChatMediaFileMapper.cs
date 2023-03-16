using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Chat Media File Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMediaFileMapper : BaseMapper<DalAppDTO.ChatMediaFile, DomainApp.ChatMediaFile>
{
    /// <summary>
    /// Basic Chat Media File Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMediaFileMapper(IMapper mapper) : base(mapper) { }
}