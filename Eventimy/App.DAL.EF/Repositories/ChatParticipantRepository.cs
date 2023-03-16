using AutoMapper;
using App.DAL.EF.Mappers;
using App.Domain.Identity;
using Base.DAL.EF.Repositories;
using App.Contracts.DAL.Repositories;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Chat Participant Data Access Layer Repository Design Implementation.
/// </summary>
public class ChatParticipantRepository : BaseEntityRepository<DalAppDTO.ChatParticipant, DomainApp.ChatParticipant, AppUser, AppDbContext>, 
    IChatParticipantRepository
{
    /// <summary>
    /// Data Access Layer Chat Participant Repository Basic Constructor Defines Connection To The Database Layer. 
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatParticipantRepository(AppDbContext dbContext, IMapper mapper) : 
        base(dbContext, new ChatParticipantMapper(mapper)) { }
}