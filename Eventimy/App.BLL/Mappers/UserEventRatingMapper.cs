using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// User Event Rating Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserEventRatingMapper : BaseMapper<BllAppDTO.UserEventRating, DalAppDTO.UserEventRating>
{
    /// <summary>
    /// Basic User Event Rating Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserEventRatingMapper(IMapper mapper) : base(mapper) { }
}