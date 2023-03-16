using App.DAL.DTO.Identity;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories.Identity;


/// <summary>
/// Refresh Token Data Access Layer Repository Design: Basic and Custom Refresh Token Repository Methods.
/// </summary>
public interface IRefreshTokenRepository : IEntityRepository<RefreshToken>, 
    IRefreshTokenRepositoryCustom<RefreshToken> { }


/// <summary>
/// Refresh Token Data Access Layer Repository Design: Custom Refresh Token Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IRefreshTokenRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Refresh Token.
    
    /* Refresh Tokens Are Absolutely Not Public Thing.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Refresh Tokens For Specific User. (Basically One Token Should Be Returned)
     * 
     */
}