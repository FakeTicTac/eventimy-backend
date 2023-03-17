namespace Base.Contracts.BLL.Mappers;


/// <summary>
/// Business Logic Layer Mapping Rule Profile Design.
/// </summary>
/// <typeparam name="TLeftObject">First Object To Proceed Mapping.</typeparam>
/// <typeparam name="TRightObject">Second Object To Proceed Mapping.</typeparam>
public interface IBaseMapper<TLeftObject, TRightObject> : Contracts.DAL.Mappers.IBaseMapper<TLeftObject, TRightObject>
    where TLeftObject : class
    where TRightObject : class { }