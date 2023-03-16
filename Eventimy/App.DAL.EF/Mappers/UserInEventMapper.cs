using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// User In Event Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserInEventMapper : BaseMapper<DalAppDTO.UserInEvent, DomainApp.UserInEvent>
{
    /// <summary>
    /// Basic User In Event Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserInEventMapper(IMapper mapper) : base(mapper) { }
}