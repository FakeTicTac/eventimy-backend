using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Event Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class EventController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Event Mapper Connection Definition.
    /// </summary>
    private readonly EventMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new EventMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Events.
    /// </summary>
    /// <returns>IEnumerable of Events.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chat>>> GetEvents() =>
        Ok((await _bll.Events.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Event.
    /// </summary>
    /// <param name="id">Event ID Value To Search For Event.</param>
    /// <returns>Event Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Event>> GetEvent(Guid id)
    {
        var appEvent = await _bll.Events.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (appEvent == null) return NotFound();
        
        return _mapper.Map(appEvent)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Event In Database Layer.
    /// </summary>
    /// <param name="id">Event ID Value of Event To Be Updated.</param>
    /// <param name="appEvent">Defines Event Value To Be Updated.</param>
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
    public async Task<IActionResult> PutEvent(Guid id, Event appEvent)
    {
        if (!id.Equals(appEvent.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.Events.Update(_mapper.Map(appEvent)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Event Record In Database Layer.
    /// </summary>
    /// <param name="appEvent">Object Value To Be Created In Database.</param>
    /// <returns>Created Event Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Event>> PostEvent(Event appEvent)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllEvent = _bll.Events.Add(_mapper.Map(appEvent)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetEvent", new
        {
            id = bllEvent.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllEvent);
    }

    /// <summary>
    /// Method Deletes Event In The Database Layer.
    /// </summary>
    /// <param name="id">Event ID Value of Event To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        // Try To Get Record From Database.
        var appEvent = await _bll.Events.FirstOrDefaultAsync(id);

        if (appEvent == null) return NotFound();
        
        // Remove Existed Record.
        _bll.Events.Remove(appEvent);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}