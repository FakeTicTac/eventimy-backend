using Base.Contracts.Domain;


namespace Base.Contracts.DAL.Repositories;


/// <summary>
/// Data Access Layer Repository Basic Design With Predefined Guid Value Into TKey Generic.
/// </summary>
/// <typeparam name="TDalEntity">Defines Type Of The Data Transfer Object of Data Access Layer To Be Processed.</typeparam>
public interface IEntityRepository<TDalEntity> : IEntityRepository<TDalEntity, Guid>
    where TDalEntity : class, IDomainEntityId { }


/// <summary>
/// Data Access Layer Repository Basic Design. Includes Asynchronous and Synchronous Methods.
/// </summary>
/// <typeparam name="TDalEntity">Defines Type Of The Data Transfer Object of Data Access Layer To Be Processed.</typeparam>
/// <typeparam name="TKey">Defines ID Value Type To Be Processed.</typeparam>
public interface IEntityRepository<TDalEntity, TKey> : IEntityRepositoryAsync<TDalEntity, TKey>, IEntityRepositorySync<TDalEntity, TKey>
    where TDalEntity : class, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey> { }