using AutoMapper;
using Base.BLL.Mappers;
using Api.DTO.v1.Identity;


using BllAppDTO = App.BLL.DTO.Identity;


namespace Api.DTO.v1.Mappers.Identity;


/// <summary>
/// App Role Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class AppRoleMapper : BaseMapper<AppRole, BllAppDTO.AppRole>
{
    /// <summary>
    /// Basic App Role Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppRoleMapper(IMapper mapper) : base(mapper) { }
}