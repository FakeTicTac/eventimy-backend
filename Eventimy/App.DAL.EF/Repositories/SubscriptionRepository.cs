using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Subscription Data Access Layer Repository Design Implementation. 
/// </summary>
public class SubscriptionRepository : BaseEntityRepository<DalAppDTO.Subscription, DomainApp.Subscription, AppUser, AppDbContext>, 
    ISubscriptionRepository
{
    /// <summary>
    /// Data Access Layer Subscription Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public SubscriptionRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new SubscriptionMapper(mapper)) { }

    
    // Asynchronous Operations.
    
    
    /// <summary>
    /// Method Gets All Subscriptions of Given Sender ID Asynchronously.
    /// </summary>
    /// <param name="senderId">Defines User Sender ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Subscription>> GetAllBySenderIdAsync(Guid senderId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.SenderUserId.Equals(senderId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }

    /// <summary>
    /// Method Gets All Subscriptions of Given Recipient ID Asynchronously.
    /// </summary>
    /// <param name="recipientId">Defines User Recipient ID For Searching.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Subscription>> GetAllByRecipientIdAsync(Guid recipientId, bool noTracking = true)
    {
        var query = CreateQuery(noTracking);

        return (await query.Where(x => x.RecipientUserId.Equals(recipientId)).ToListAsync())
            .Select(x => Mapper.Map(x))!;
    }
}
