using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Poll Option Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class PollOptionMapper : BaseMapper<BllAppDTO.PollOption, DalAppDTO.PollOption>
{
    /// <summary>
    /// Basic Poll Option Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollOptionMapper(IMapper mapper) : base(mapper) { }
}