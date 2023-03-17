using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories.Identity;

using BllAppDTO = App.BLL.DTO.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.Contracts.BLL.Services.Identity;


/// <summary>
/// Refresh Token Business Logic Layer Service Design: Basic and Custom Refresh Token Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IRefreshTokenService : IEntityService<BllAppDTO.RefreshToken, DalAppDTO.RefreshToken>,
    IRefreshTokenServiceCustom<BllAppDTO.RefreshToken, DalAppDTO.RefreshToken>,
    IRefreshTokenRepositoryCustom<BllAppDTO.RefreshToken> { }


/// <summary>
/// Refresh Token Business Logic Layer Service Design: Custom Refresh Token Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IRefreshTokenServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}