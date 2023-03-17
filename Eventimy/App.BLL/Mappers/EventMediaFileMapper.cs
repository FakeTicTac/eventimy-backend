﻿using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Event Media File Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class EventMediaFileMapper : BaseMapper<BllAppDTO.EventMediaFile, DalAppDTO.EventMediaFile>
{
    /// <summary>
    /// Basic Event Media File Mapper Constructor. Defines Connection To The Mapper. 
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventMediaFileMapper(IMapper mapper) : base(mapper) { }
}