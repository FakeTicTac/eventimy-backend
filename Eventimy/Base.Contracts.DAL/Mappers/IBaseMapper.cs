namespace Base.Contracts.DAL.Mappers;


/// <summary>
/// Data Access Layer Mapping Rule Profile Design.
/// </summary>
/// <typeparam name="TLeftObject">First Object To Proceed Mapping.</typeparam>
/// <typeparam name="TRightObject">Second Object To Proceed Mapping.</typeparam>
public interface IBaseMapper<TLeftObject, TRightObject> where TLeftObject: class where TRightObject: class
{
    /// <summary>
    /// Method Maps the Left Object to the Right Object.
    /// </summary>
    /// <param name="inObject">Defines Object To Be Mapped.</param>
    /// <returns>Left Object Mapped To Right Object.</returns>
    TRightObject? Map(TLeftObject? inObject);

    /// <summary>
    /// Method Maps the Right Object to the Left Object.
    /// </summary>
    /// <param name="inObject">Defines Object To Be Mapped.</param>
    /// <returns>Right Object Mapped To Left Object.</returns>
    TLeftObject? Map(TRightObject? inObject);
}