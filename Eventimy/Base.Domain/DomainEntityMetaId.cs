using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


namespace Base.Domain;


/// <summary>
/// Basic Database Meta-data Entity Implementation: Uses Guid Value as Primary Key Type.
/// </summary>
public abstract class DomainEntityMetaId : DomainEntityMetaId<Guid>, IDomainEntityId { }


/// <summary>
/// Basic Database Meta-data Entity Implementation: Defines Common Rows in Database Table.
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class DomainEntityMetaId<TKey> : DomainEntityId<TKey>, IDomainEntityMeta
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Defines Data Insertion Time. 
    /// </summary>
    [MaxLength(64)]
    public string? CreatedBy { get; set; }
    
    /// <summary>
    /// Defines User/System Who Inserted The Data.
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    
    /// <summary>
    /// Defines Data Update Time. 
    /// </summary>
    [MaxLength(64)]
    public string? ModifiedBy { get; set; }
    
    /// <summary>
    /// Defines User/System Who Updated The Data.
    /// </summary>
    public DateTime? ModifiedAt { get; set; }
}