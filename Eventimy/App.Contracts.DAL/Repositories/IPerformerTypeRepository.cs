using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Performer Type Data Access Layer Repository Design: Basic and Custom Performer Type Repository Methods.
/// </summary>
public interface IPerformerTypeRepository : IEntityRepository<PerformerType>, 
    IPerformerTypeRepositoryCustom<PerformerType> { }


/// <summary>
/// Performer Type Data Access Layer Repository Design: Custom Performer Type Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IPerformerTypeRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Performer Type. (No Security Applied On This Level)

    /* Performer Types Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Performer Types. (Visible Absolutely To Everyone)
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access All Performer Types With Part Of Its' Title.
     * 
     */
}