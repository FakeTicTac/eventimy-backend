using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Media File Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class MediaFileTypeMapper : BaseMapper<DalAppDTO.MediaFileType, DomainApp.MediaFileType>
{
    /// <summary>
    /// Basic Media File Type Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public MediaFileTypeMapper(IMapper mapper) : base(mapper) { }
}