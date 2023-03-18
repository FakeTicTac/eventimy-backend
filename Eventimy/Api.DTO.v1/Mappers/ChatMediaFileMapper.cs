using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Chat Media File Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMediaFileMapper : BaseMapper<ChatMediaFile, BllAppDTO.ChatMediaFile>
{
    /// <summary>
    /// Basic Chat Media File Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMediaFileMapper(IMapper mapper) : base(mapper) { }
}