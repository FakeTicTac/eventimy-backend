using Base.Contracts.DAL;
using Base.Contracts.BLL;


namespace Base.BLL;


/// <summary>
/// Business Logic Layer Service Basic Design Implementation.
/// </summary>
/// <typeparam name="TUnitOfWork">Data Access Layer Unit Of Work Connection Definition.</typeparam>
public class BaseBusinessLogic<TUnitOfWork> : IBusinessLogic
    where TUnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Data Access Layer Connection Definition. Connection To All Unit Of Work Repositories.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly TUnitOfWork Uow;


    /// <summary>
    /// Service Constructor Defines Connection With Data Access Layer (Unit of Work). 
    /// </summary>
    /// <param name="uow">ata Access Layer Connection Definition.</param>
    // ReSharper disable once MemberCanBeProtected.Global
    public BaseBusinessLogic(TUnitOfWork uow) => Uow = uow;
 

    /// <summary>
    /// Method Saves Changes in The Database Asynchronously.
    /// </summary>
    /// <returns>Asynchronous Operation That Returns Number of Objects Updated in The Database.</returns>
    public async Task<int> SaveChangesAsync() => await Uow.SaveChangesAsync();

    /// <summary>
    /// Method Saves Changes in The Database Synchronously.
    /// </summary>
    /// <returns>Number of Objects Updated in The Database.</returns>
    public int SaveChanges() => Uow.SaveChanges();
    
    
    /// <summary>
    /// Dictionary Stores Business Logic Layer Services.
    /// </summary>
    private readonly Dictionary<Type, object> _serviceCache = new();
    
    /// <summary>
    /// Method Creates Services - Service Factory. Manages Unlimited Instances Creation.
    /// </summary>
    /// <param name="serviceCreationMethod">Service Creation Method.</param>
    /// <typeparam name="TService">Service Type To Be Created.</typeparam>
    /// <returns>Created Service of Type TService.</returns>
    public TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class
    {
        // Check if Service Was Already Created.
        if (_serviceCache.TryGetValue(typeof(TService), out var repo)) return (TService) repo;
            
        // Create New Repository And Add It To The Repository Dictionaries.
        var serviceInstance = serviceCreationMethod();
        _serviceCache.Add(typeof(TService), serviceInstance);
            
        return serviceInstance;
    }
}
