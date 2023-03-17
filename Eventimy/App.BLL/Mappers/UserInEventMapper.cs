using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// User In Event Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserInEventMapper : BaseMapper<BllAppDTO.UserInEvent, DalAppDTO.UserInEvent>
{
    /// <summary>
    /// Basic User In Event Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserInEventMapper(IMapper mapper) : base(mapper) { }
}