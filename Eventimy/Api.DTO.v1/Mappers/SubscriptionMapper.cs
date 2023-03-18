using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Subscription Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class SubscriptionMapper : BaseMapper<Subscription, BllAppDTO.Subscription>
{
    /// <summary>
    /// Basic Subscription Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public SubscriptionMapper(IMapper mapper) : base(mapper) { }
}