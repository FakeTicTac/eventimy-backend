using Base.Contracts.Domain;


namespace Base.Contracts.DAL.Repositories;


/// <summary>
/// Data Access Layer Repository Design. Only Synchronous Execution Methods.
/// </summary>
/// <typeparam name="TDalEntity">Defines Type Of The Data Transfer Object of Data Access Layer To Be Processed.</typeparam>
/// <typeparam name="TKey">Defines ID Value Type To Be Processed.</typeparam>
// ReSharper disable once TypeParameterCanBeVariant
public interface IEntityRepositorySync<TDalEntity, in TKey>
    where TDalEntity : class, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Method Adds Entity To The Database Synchronously.
    /// </summary>
    /// <param name="entity">Defines Entity To Be Added To The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Added Entity.</returns>
    TDalEntity Add(TDalEntity entity, object? userId = null);

    /// <summary>
    /// Method Updates Entity in The Database Synchronously.
    /// </summary>
    /// <param name="entity">Defines Entity To Be Updated in The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Updated Entity.</returns>
    TDalEntity Update(TDalEntity entity, object? userId = null);

    /// <summary>
    /// Method Removes Entity From The Database Synchronously Using ID.
    /// </summary>
    /// <param name="id">Defines Entity ID To Be Removed From The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Removed Entity.</returns>
    TDalEntity Remove(TKey id, object? userId = null);

    /// <summary>
    /// Method Removes Entity From The Database Synchronously Using Generated Entity.
    /// </summary>
    /// <param name="entity">Defines Entity To Be Removed From The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Removed Entity.</returns>
    TDalEntity Remove(TDalEntity entity, object? userId = null);

    /// <summary>
    /// Method Get All Entities of The Given Type From The Database Synchronously.
    /// </summary>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">Defines Tracking Option.</param>
    /// <returns>The Value of Enumerable of Entities.</returns>
    IEnumerable<TDalEntity> GetAll(object? userId = null, bool noTracking = true);

    /// <summary>
    /// Method Get Entity of The Given Type ID The Database Synchronously if Found or Null.
    /// </summary>
    /// <param name="id">Defines Entity ID To Be Searched in The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <param name="noTracking">Defines Tracking Option.</param>
    /// <returns>The Value of Found Entity or Null.</returns>
    TDalEntity? FirstOrDefault(TKey id, object? userId = null, bool noTracking = true);

    /// <summary>
    /// Method Indicates If Entity With Given ID Exist In Database.
    /// </summary>
    /// <param name="id">Defines Entity ID To Be Searched in The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Boolean as an Indicator of Entity Existence.</returns>
    bool Exist(TKey id, object? userId = null);
}