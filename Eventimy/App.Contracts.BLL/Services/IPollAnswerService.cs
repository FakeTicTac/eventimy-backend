using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Poll Answer Business Logic Layer Service Design: Basic and Custom Poll Answer Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IPollAnswerService : IEntityService<BllAppDTO.PollAnswer, DalAppDTO.PollAnswer>, 
    IPollAnswerService<BllAppDTO.PollAnswer, DalAppDTO.PollAnswer>,
    IPollAnswerRepositoryCustom<BllAppDTO.PollAnswer> { }


/// <summary>
/// Poll Answer Business Logic Layer Service Design: Custom Poll Answer Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IPollAnswerService<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}