using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Media File Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class MediaFileTypeMapper : BaseMapper<MediaFileType, BllAppDTO.MediaFileType>
{
    /// <summary>
    /// Basic Media File Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public MediaFileTypeMapper(IMapper mapper) : base(mapper) { }
}