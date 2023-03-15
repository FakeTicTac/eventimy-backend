using Base.Contracts.Domain;
using Microsoft.AspNetCore.Identity;


namespace Base.Domain.Identity;


/// <summary>
/// Basic Identity User Implementation. Uses Guid Value as Primary Key Type.
/// </summary>
public class BaseUser : BaseUser<Guid>, IDomainEntityId { }


/// <summary>
/// Basic Identity User Implementation. Defines Common Rows in User Database Table.
/// </summary>
/// <typeparam name="TKey">Entity Primary Key Definition.</typeparam>
public class BaseUser<TKey> : IdentityUser<TKey>, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey> { }