using AutoMapper;
using Base.BLL.Mappers;
using Api.DTO.v1.Identity;


using BllAppDTO = App.BLL.DTO.Identity;


namespace Api.DTO.v1.Mappers.Identity;


/// <summary>
/// App User Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class AppUserMapper : BaseMapper<AppUser, BllAppDTO.AppUser>
{
    /// <summary>
    /// Basic App User Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppUserMapper(IMapper mapper) : base(mapper) { }
}