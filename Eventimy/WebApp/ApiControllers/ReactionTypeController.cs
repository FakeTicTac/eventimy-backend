using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Chat Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class ReactionTypeController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Reaction Type Mapper Connection Definition.
    /// </summary>
    private readonly ReactionTypeMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ReactionTypeController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new ReactionTypeMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Reaction Types.
    /// </summary>
    /// <returns>IEnumerable of Reaction Types.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ReactionType>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReactionType>>> GetReactionTypes() =>
        Ok((await _bll.ReactionTypes.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Reaction Type.
    /// </summary>
    /// <param name="id">Reaction Type ID Value To Search For Reaction Type.</param>
    /// <returns>Reaction Type Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReactionType>> GetReactionType(Guid id)
    {
        var reactionType = await _bll.ReactionTypes.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (reactionType == null) return NotFound();
        
        return _mapper.Map(reactionType)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Reaction Type In Database Layer.
    /// </summary>
    /// <param name="id">Reaction Type ID Value of Reaction Type To Be Updated.</param>
    /// <param name="reactionType">Defines Reaction Type Value To Be Updated.</param>
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
    public async Task<IActionResult> PutReactionType(Guid id, ReactionType reactionType)
    {
        if (!id.Equals(reactionType.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.ReactionTypes.Update(_mapper.Map(reactionType)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Reaction Type Record In Database Layer.
    /// </summary>
    /// <param name="reactionType">Object Value To Be Created In Database.</param>
    /// <returns>Created Reaction Type Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<ActionResult<Chat>> PostReactionType(ReactionType reactionType)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllReactionType = _bll.ReactionTypes.Add(_mapper.Map(reactionType)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetReactionType", new
        {
            id = bllReactionType.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllReactionType);

    }

    /// <summary>
    /// Method Deletes Reaction Type In The Database Layer.
    /// </summary>
    /// <param name="id">Reaction Type ID Value of Reaction Type To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteReactionType(Guid id)
    {
        // Try To Get Record From Database.
        var reactionType = await _bll.ReactionTypes.FirstOrDefaultAsync(id);

        if (reactionType == null) return NotFound();
        
        // Remove Existed Record.
        _bll.ReactionTypes.Remove(reactionType);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}