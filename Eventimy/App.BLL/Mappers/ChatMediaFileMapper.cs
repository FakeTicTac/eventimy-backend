using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Chat Media File Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class ChatMediaFileMapper : BaseMapper<BllAppDTO.ChatMediaFile, DalAppDTO.ChatMediaFile>
{
    /// <summary>
    /// Basic Chat Media File Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMediaFileMapper(IMapper mapper) : base(mapper) { }
}