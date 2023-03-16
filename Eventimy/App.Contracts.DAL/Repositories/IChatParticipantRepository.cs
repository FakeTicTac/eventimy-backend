using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Chat Participant Data Access Layer Repository Design: Basic and Custom Chat Participant Repository Methods. 
/// </summary>
public interface IChatParticipantRepository : IEntityRepository<ChatParticipant>, 
    IChatParticipantRepositoryCustom<ChatParticipant> { }


/// <summary>
/// Chat Participant Data Access Layer Repository Design: Custom Chat Participant Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
public interface IChatParticipantRepositoryCustom<TEntity>
{
    // App Specific Custom Method For Chat Participant Repository. (No Security Applied On This Level For Accessing)
    
    // Main Point Of Application Data Loading - A Lot Of Small Requests Instead Of One And Big.

    /* Chat Participants Are Not In Public Access:
     *
     *  *** Not Covered In Basic Implementation. ***
     *  - Users Can Access Chat Participants of The Given Chat if They Are Participant Or Owner Of Chat.
     * 
     */
}