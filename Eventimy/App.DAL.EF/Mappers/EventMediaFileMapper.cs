using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Event Media File Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class EventMediaFileMapper : BaseMapper<DalAppDTO.EventMediaFile, DomainApp.EventMediaFile>
{
    /// <summary>
    /// Basic Event Media File Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventMediaFileMapper(IMapper mapper) : base(mapper) { }
}