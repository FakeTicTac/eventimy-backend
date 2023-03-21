using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Performer Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class PerformerController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Performer Mapper Connection Definition.
    /// </summary>
    private readonly PerformerMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PerformerController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new PerformerMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Performers.
    /// </summary>
    /// <returns>IEnumerable of Performers.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Chat>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chat>>> GetPerformers() =>
        Ok((await _bll.Performers.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Performer.
    /// </summary>
    /// <param name="id">Performer ID Value To Search For Performer.</param>
    /// <returns>Performer Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Performer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Performer>> GetPerformer(Guid id)
    {
        var performer = await _bll.Performers.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (performer == null) return NotFound();
        
        return _mapper.Map(performer)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Performer In Database Layer.
    /// </summary>
    /// <param name="id">Performer ID Value of Performer To Be Updated.</param>
    /// <param name="performer">Defines Performer Value To Be Updated.</param>
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
    public async Task<IActionResult> PutPerformer(Guid id, Performer performer)
    {
        if (!id.Equals(performer.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.Performers.Update(_mapper.Map(performer)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Performer Record In Database Layer.
    /// </summary>
    /// <param name="performer">Object Value To Be Created In Database.</param>
    /// <returns>Created Performer Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Performer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Performer>> PostPerformer(Performer performer)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllPerformer = _bll.Performers.Add(_mapper.Map(performer)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetPerformer", new
        {
            id = bllPerformer.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllPerformer);

    }

    /// <summary>
    /// Method Deletes Performer In The Database Layer.
    /// </summary>
    /// <param name="id">Performer ID Value of Performer To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePerformer(Guid id)
    {
        // Try To Get Record From Database.
        var performer = await _bll.Performers.FirstOrDefaultAsync(id);

        if (performer == null) return NotFound();
        
        // Remove Existed Record.
        _bll.Performers.Remove(performer);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}