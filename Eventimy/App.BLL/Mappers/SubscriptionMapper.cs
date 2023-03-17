using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Subscription Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class SubscriptionMapper : BaseMapper<BllAppDTO.Subscription, DalAppDTO.Subscription>
{
    /// <summary>
    /// Basic Subscription Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public SubscriptionMapper(IMapper mapper) : base(mapper) { }
}