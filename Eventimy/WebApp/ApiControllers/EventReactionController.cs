using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Event Reaction Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class EventReactionController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Event Reaction Mapper Connection Definition.
    /// </summary>
    private readonly EventReactionMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventReactionController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new EventReactionMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Event Reactions.
    /// </summary>
    /// <returns>IEnumerable of Event Reactions.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<EventReaction>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EventReaction>>> GetEventReactions() =>
        Ok((await _bll.EventReactions.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Event Reaction.
    /// </summary>
    /// <param name="id">Event Reaction ID Value To Search For Event Reaction.</param>
    /// <returns>Event Reaction Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EventReaction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventReaction>> GetEventReaction(Guid id)
    {
        var eventReaction = await _bll.EventReactions.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (eventReaction == null) return NotFound();
        
        return _mapper.Map(eventReaction)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Event Reaction In Database Layer.
    /// </summary>
    /// <param name="id">Event Reaction ID Value of Chat To Be Updated.</param>
    /// <param name="eventReaction">Defines Event Reaction Value To Be Updated.</param>
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
    public async Task<IActionResult> PutEventReaction(Guid id, EventReaction eventReaction)
    {
        if (!id.Equals(eventReaction.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.EventReactions.Update(_mapper.Map(eventReaction)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Event Reaction Record In Database Layer.
    /// </summary>
    /// <param name="eventReaction">Object Value To Be Created In Database.</param>
    /// <returns>Created Event Reaction Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<EventReaction>> PostEventReaction(EventReaction eventReaction)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllEventReaction = _bll.EventReactions.Add(_mapper.Map(eventReaction)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetEventReaction", new
        {
            id = bllEventReaction.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllEventReaction);
    }

    /// <summary>
    /// Method Deletes Event Reaction In The Database Layer.
    /// </summary>
    /// <param name="id">Event Reaction ID Value of Event Reaction To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEventReaction(Guid id)
    {
        // Try To Get Record From Database.
        var eventReaction = await _bll.EventReactions.FirstOrDefaultAsync(id);

        if (eventReaction == null) return NotFound();
        
        // Remove Existed Record.
        _bll.EventReactions.Remove(eventReaction);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}