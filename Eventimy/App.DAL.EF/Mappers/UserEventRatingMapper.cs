using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// User Event Rating Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserEventRatingMapper : BaseMapper<DalAppDTO.UserEventRating, DomainApp.UserEventRating>
{
    /// <summary>
    /// Basic User Event Rating Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserEventRatingMapper(IMapper mapper) : base(mapper) { }
}