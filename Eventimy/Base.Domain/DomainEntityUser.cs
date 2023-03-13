using Base.Contracts.Domain.Identity;


namespace Base.Domain;


/// <summary>
/// Basic Database Identity Related Entity Implementation. Uses Guid Value as Primary Key Type.
/// </summary>
/// <typeparam name="TAppUser">Entity User Identity Object Definition.</typeparam>
public abstract class DomainEntityUser<TAppUser> : DomainEntityUser<Guid, TAppUser>
    where TAppUser : class { }


/// <summary>
/// Basic Database Identity Related Entity Implementation. Defines Common Rows in Basic Entity Database Table.
/// </summary>
/// <typeparam name="TKey">Entity Primary Key Definition.</typeparam>
/// <typeparam name="TAppUser">Entity User Identity Object Definition.</typeparam>
public abstract class DomainEntityUser<TKey, TAppUser> : DomainEntityMetaId<TKey>, IDomainEntityUser<TAppUser>
    where TKey : IEquatable<TKey>
    where TAppUser : class
{
    /// <summary>
    /// Entity Foreign Key To Identity System Definition.
    /// </summary>
    public Guid AppUserId { get; set; }
    
    /// <summary>
    /// Entity Connection Object To Identity System Definition.
    /// </summary>
    public TAppUser? AppUser { get; set; }
}