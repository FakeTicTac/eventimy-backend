namespace Base.Contracts.DAL;


/// <summary>
/// Unit of Work Design Pattern. Wrapper Data Access Layer Around Repositories.
/// </summary>l
public interface IUnitOfWork
{
    /// <summary>
    /// Method Saves Changes in The Database Asynchronously.
    /// </summary>
    /// <returns>Asynchronous Operation That Returns Number of Objects Updated in The Database.</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Method Saves Changes in The Database Synchronously.
    /// </summary>
    /// <returns>Number of Objects Updated in The Database.</returns>
    int SaveChanges();
    
    /// <summary>
    /// Method Creates Repositories - Repository Factory. Manages Unlimited Instances Creation.
    /// </summary>
    /// <param name="repoCreationMethod">Repository Creation Method.</param>
    /// <typeparam name="TRepository">Repository Type To Be Created.</typeparam>
    /// <returns>Created Repository of Type TRepository.</returns>
    TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod) where TRepository : class;
}