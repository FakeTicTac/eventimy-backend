using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// User Event Rating Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserEventRatingMapper : BaseMapper<UserEventRating, BllAppDTO.UserEventRating>
{
    /// <summary>
    /// Basic User Event Rating Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserEventRatingMapper(IMapper mapper) : base(mapper) { }
}