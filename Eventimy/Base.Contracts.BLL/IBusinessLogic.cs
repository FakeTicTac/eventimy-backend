namespace Base.Contracts.BLL;


/// <summary>
/// Class Defines Business Logic Handler Design.
/// </summary>
public interface IBusinessLogic
{
    /// <summary>
    /// Method Saves Changes Made In Service Layer Next Through The Pipeline Asynchronously.
    /// </summary>
    /// <returns>Number of Objects Updated in The Database.</returns>
    Task<int> SaveChangesAsync();
    
    /// <summary>
    /// Method Saves Changes Made In Service Layer Next Through The Pipeline Synchronously.
    /// </summary>
    /// <returns>Number of Objects Updated in The Database.</returns>
    int SaveChanges();
    
    /// <summary>
    /// Method Creates Services - Service Factory. Manages Unlimited Instances Creation.
    /// </summary>
    /// <param name="serviceCreationMethod">Service Creation Method.</param>
    /// <typeparam name="TService">Service To Be Created.</typeparam>
    /// <returns>Created Service Of Type TService.</returns>
    TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class;
}