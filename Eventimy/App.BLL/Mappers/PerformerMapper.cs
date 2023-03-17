using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Performer Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PerformerMapper : BaseMapper<BllAppDTO.Performer, DalAppDTO.Performer>
{
    /// <summary>
    /// Basic Performer Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerMapper(IMapper mapper) : base(mapper) { }
}