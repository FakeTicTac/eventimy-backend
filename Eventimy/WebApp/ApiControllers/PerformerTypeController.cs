using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Performer Type Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class PerformerTypeController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Performer Type Mapper Connection Definition.
    /// </summary>
    private readonly PerformerTypeMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerTypeController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new PerformerTypeMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Performer Types.
    /// </summary>
    /// <returns>IEnumerable of Performer Types.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<PerformerType>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PerformerType>>> GetPerformerTypes() =>
        Ok((await _bll.PerformerTypes.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Performer Type.
    /// </summary>
    /// <param name="id">Performer Type ID Value To Search For Performer Type.</param>
    /// <returns>Performer Type Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PerformerType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PerformerType>> GetPerformerType(Guid id)
    {
        var performerType = await _bll.PerformerTypes.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (performerType == null) return NotFound();
        
        return _mapper.Map(performerType)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Performer Type In Database Layer.
    /// </summary>
    /// <param name="id">Performer Type ID Value of Performer Type To Be Updated.</param>
    /// <param name="performerType">Defines Performer Type Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> PutPerformerType(Guid id, PerformerType performerType)
    {
        if (!id.Equals(performerType.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.PerformerTypes.Update(_mapper.Map(performerType)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Performer Type Record In Database Layer.
    /// </summary>
    /// <param name="performerType">Object Value To Be Created In Database.</param>
    /// <returns>Created Performer Type Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(PerformerType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<ActionResult<Chat>> PostPerformerType(PerformerType performerType)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllPerformerType = _bll.PerformerTypes.Add(_mapper.Map(performerType)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetPerformerType", new
        {
            id = bllPerformerType.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllPerformerType);

    }

    /// <summary>
    /// Method Deletes Performer Type In The Database Layer.
    /// </summary>
    /// <param name="id">Performer Type ID Value of Performer Type To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> DeletePerformerType(Guid id)
    {
        // Try To Get Record From Database.
        var performerType = await _bll.PerformerTypes.FirstOrDefaultAsync(id);

        if (performerType == null) return NotFound();
        
        // Remove Existed Record.
        _bll.PerformerTypes.Remove(performerType);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}