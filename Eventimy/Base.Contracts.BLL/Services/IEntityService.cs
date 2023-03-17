using Base.Contracts.Domain;
using Base.Contracts.DAL.Repositories;


namespace Base.Contracts.BLL.Services;


/// <summary>
/// Business Logic Layer Service Basic Design With Predefined Guid Value Into TKey Generic.
/// </summary>
/// <typeparam name="TBllEntity">Defines Type Of The Data Transfer Object of Business Logic Layer To Be Processed.</typeparam>
/// <typeparam name="TDalEntity">Defines Type Of The Data Transfer Object of Data Access Layer To Be Processed.</typeparam>
public interface IEntityService<TBllEntity, TDalEntity> : IEntityService<TBllEntity, TDalEntity, Guid>
    where TBllEntity : class, IDomainEntityId
    where TDalEntity : class, IDomainEntityId { }


/// <summary>
/// Business Logic Layer Service Basic Design.
/// </summary>
/// <typeparam name="TBllEntity">Defines Type Of The Data Transfer Object of Business Logic Layer To Be Processed.</typeparam>
/// <typeparam name="TDalEntity">Defines Type Of The Data Transfer Object of Data Access Layer To Be Processed.</typeparam>
/// <typeparam name="TKey">Defines ID Value Type To Be Processed.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IEntityService<TBllEntity, TDalEntity, TKey> : IEntityRepository<TBllEntity, TKey>, IBaseService
    where TBllEntity : class, IDomainEntityId<TKey>
    where TDalEntity : class, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey> { }