using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Reaction Type Data Access Layer Repository Design: Basic and Custom Reaction Type Repository Methods.
/// </summary>
public interface IReactionTypeRepository : IEntityRepository<ReactionType>, 
    IReactionTypeRepositoryCustom<ReactionType> { }


/// <summary>
/// Reaction Type Data Access Layer Repository Design: Custom Reaction Type Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IReactionTypeRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Reaction Type. (No Security Applied On This Level)
    
    /* Reaction Types Are Public Thing And Everybody Can See It.
     *
     *  *** Already Covered In Basic Implementation. ***
     *  - Users Can Access All Reaction Types. (Visible Absolutely To Everyone)
     * 
     */
}