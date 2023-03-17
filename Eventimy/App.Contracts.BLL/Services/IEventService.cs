﻿using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;

using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Event Business Logic Layer Service Design: Basic and Custom Event Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IEventService : IEntityService<BllAppDTO.Event, DalAppDTO.Event>,
    IEventServiceCustom<BllAppDTO.Event, DalAppDTO.Event>,
    IEventRepositoryCustom<BllAppDTO.Event> { }


/// <summary>
/// Event Business Logic Layer Service Design: Custom Event Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IEventServiceCustom<TBllEntity, TDalEntity>
{
    // App Specific Custom Method For Chat Message Service. (Partial Security Applied On This Level)
}