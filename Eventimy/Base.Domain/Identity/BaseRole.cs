using Base.Contracts.Domain;
using Microsoft.AspNetCore.Identity;


namespace Base.Domain.Identity;


/// <summary>
/// Basic Identity Role Implementation. Uses Guid Value as Primary Key Type.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class BaseRole : BaseRole<Guid>, IDomainEntityId { }


/// <summary>
/// Basic Identity Role Implementation. Defines Common Rows in User Role Database Table.
/// </summary>
/// <typeparam name="TKey">Entity Primary Key Definition.</typeparam>
public class BaseRole<TKey> : IdentityRole<TKey>, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey> { }