using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Subscription Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class SubscriptionMapper : BaseMapper<DalAppDTO.Subscription, DomainApp.Subscription>
{
    /// <summary>
    /// Basic Subscription Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public SubscriptionMapper(IMapper mapper) : base(mapper) { }
}