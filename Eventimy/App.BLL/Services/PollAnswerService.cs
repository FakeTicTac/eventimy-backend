using AutoMapper;
using App.BLL.Mappers;
using App.Contracts.DAL;
using Base.BLL.Services;
using App.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Services;


/// <summary>
/// Poll Answer Business Logic Layer Service Design Implementation.
/// </summary>
public class PollAnswerService : BaseEntityService<BllAppDTO.PollAnswer, DalAppDTO.PollAnswer, IAppUnitOfWork, IPollAnswerRepository>, 
    IPollAnswerService
{
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollAnswerService(IAppUnitOfWork serviceUow, IPollAnswerRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new PollAnswerMapper(mapper)) { }

    
    // Asynchronous Operations.


    /// <summary>
    /// Method Gets All Poll Answers By Given Poll Option Asynchronously.
    /// </summary>
    /// <param name="pollOptionId">Defines Poll Option ID To Search For Poll Answers.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.PollAnswer>> GetAllByPollOptionIdAsync(Guid pollOptionId, bool noTracking = true) =>
        (await ServiceRepository.GetAllByPollOptionIdAsync(pollOptionId, noTracking)).Select(x => Mapper.Map(x))!;
}