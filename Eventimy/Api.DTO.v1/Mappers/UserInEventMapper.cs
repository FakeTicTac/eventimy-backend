using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// User In Event Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserInEventMapper : BaseMapper<UserInEvent, BllAppDTO.UserInEvent>
{
    /// <summary>
    /// Basic User In Event Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserInEventMapper(IMapper mapper) : base(mapper) { }
}