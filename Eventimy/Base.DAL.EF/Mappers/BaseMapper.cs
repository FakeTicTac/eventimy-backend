using AutoMapper;
using Base.Contracts.DAL.Mappers;


namespace Base.DAL.EF.Mappers;


/// <summary>
/// Data Access Layer Mapping Rule Profile Design Implementation.
/// </summary>
/// <typeparam name="TLeftObject">First Object To Proceed Mapping.</typeparam>
/// <typeparam name="TRightObject">Second Object To Proceed Mapping.</typeparam>
public class BaseMapper<TLeftObject, TRightObject> : IBaseMapper<TLeftObject, TRightObject>
    where TLeftObject : class
    where TRightObject : class
{
    /// <summary>
    /// Mapper Connection Definition.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly IMapper Mapper;
        
        
    /// <summary>
    /// Base Mapper Constructor: Defines Connection to The Mapper Profile.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    // ReSharper disable once MemberCanBeProtected.Global
    public BaseMapper(IMapper mapper) => Mapper = mapper;

    
    /// <summary>
    /// Method Maps the Left Object to the Right Object.
    /// </summary>
    /// <param name="inObject">Defines Object To Be Mapped.</param>
    /// <returns>Left Object Mapped To Right Object.</returns>
    public virtual TRightObject? Map(TLeftObject? inObject) => Mapper.Map<TRightObject>(inObject);

    /// <summary>
    /// Method Maps the Right Object to the Left Object.
    /// </summary>
    /// <param name="inObject">Defines Object To Be Mapped.</param>
    /// <returns>Right Object Mapped To Left Object.</returns>
    public virtual TLeftObject? Map(TRightObject? inObject) => Mapper.Map<TLeftObject>(inObject);
}