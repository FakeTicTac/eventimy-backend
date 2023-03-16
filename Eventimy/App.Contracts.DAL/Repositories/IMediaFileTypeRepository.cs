using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Media File Type Data Access Layer Repository Design: Basic and Custom Media File Type Repository Methods.
/// </summary>
public interface IMediaFileTypeRepository : IEntityRepository<MediaFileType>, 
    IMediaFileTypeRepositoryCustom<MediaFileType> { }


/// <summary>
/// Media File Type Data Access Layer Repository Design: Custom Media File Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IMediaFileTypeRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Media File Type. (No Security Applied On This Level)

    /* Media File Types Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Media File Types. (Visible Absolutely To Everyone)
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Media File Types With Part Of Its' Name.
     * 
     */
}