using AutoMapper;
using App.BLL.Mappers;
using App.Contracts.DAL;
using Base.BLL.Services;
using Base.DAL.EF.Exceptions;
using App.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Services;


/// <summary>
/// Subscription Business Logic Layer Service Design Implementation.
/// </summary>
public class SubscriptionService : BaseEntityService<BllAppDTO.Subscription, DalAppDTO.Subscription, IAppUnitOfWork, ISubscriptionRepository>, 
    ISubscriptionService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public SubscriptionService(IAppUnitOfWork serviceUow, ISubscriptionRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new SubscriptionMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Removes Given Entity From the Database using Guid Value as Indicator. Only Recipient Or Sender Can Modify.
    /// </summary>
    /// <param name="id">Defines Entity ID To Be Removed From The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Removed Entity.</returns>
    /// <exception cref="NullReferenceException">Thrown if Entity Doesn't Exist in Database.</exception>
    public override BllAppDTO.Subscription Remove(Guid id, object? userId = null)
    {
        // Try To Get Entity From Database Layer.
        var entity = FirstOrDefault(id);
        
        // Check If Data Exist.
        if (entity == null) 
            throw new DataExistenceException($"Entity with given ID {id} doesn't exist in Database Layer.");

        return Remove(entity, userId);
    }

    /// <summary>
    /// Method Removes Given Entity From the Database. Only Recipient Or Sender Can Modify.
    /// </summary>
    /// <param name="entity">Entity Value To Be Process.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Removed Entity.</returns>
    public override BllAppDTO.Subscription Remove(BllAppDTO.Subscription entity, object? userId = null)
    {
        // Check If User Can Modify Data. He is Subscriber Or Recipient.
        if (!entity.RecipientUserId.Equals(userId) && !entity.SenderUserId.Equals(userId))
            throw new DataSecurityAccessException($"Data cannot be modified by user with {userId} ID");
        
        return base.Remove(entity, userId);
    }

    /// <summary>
    /// Method Updates Given Entity in the Database. Only Recipient Or Sender Can Modify.
    /// </summary>
    /// <param name="entity">Entity Value To Be Process.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>The Value of Updated Entity.</returns>
    public override BllAppDTO.Subscription Update(BllAppDTO.Subscription entity, object? userId = null)
    {
        // Check If User Can Modify Data. He is Subscriber Or Recipient.
        if (!entity.RecipientUserId.Equals(userId) && !entity.SenderUserId.Equals(userId))
            throw new DataSecurityAccessException($"Data cannot be modified by user with {userId} ID");
        
        return base.Update(entity, userId);
    }

    /// <summary>
    /// Method Removes Entity From The Database Asynchronously Using ID. Only Recipient Or Sender Can Modify.
    /// </summary>
    /// <param name="id">Defines Entity ID To Be Removed From The Database.</param>
    /// <param name="userId">Defines Entity Demanding User ID Value.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Removed Entity.</returns>
    public override async Task<BllAppDTO.Subscription> RemoveAsync(Guid id, object? userId = null)
    {
        // Try To Get Entity From Database Layer.
        var entity = await FirstOrDefaultAsync(id);
        
        // Check If Data Exist.
        if (entity == null) 
            throw new DataExistenceException($"Entity with given ID {id} doesn't exist in Database Layer.");

        return Remove(entity, userId);
    }

    /// <summary>
    /// Method Gets All Subscriptions of Given Sender ID Asynchronously.
    /// </summary>
    /// <param name="senderId">Defines User Sender ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Subscription>> GetAllBySenderIdAsync(Guid senderId, bool noTracking = true) =>
        (await ServiceRepository.GetAllBySenderIdAsync(senderId, noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets All Subscriptions of Given Recipient ID Asynchronously.
    /// </summary>
    /// <param name="recipientId">Defines User Recipient ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Subscription>> GetAllByRecipientIdAsync(Guid recipientId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByRecipientIdAsync(recipientId, noTracking)).Select(x => Mapper.Map(x))!;
}
