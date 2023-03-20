using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Event Category Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class EventCategoryController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Event Category Mapper Connection Definition.
    /// </summary>
    private readonly EventCategoryMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public EventCategoryController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new EventCategoryMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Event Categories.
    /// </summary>
    /// <returns>IEnumerable of Event Categories.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<EventCategory>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EventCategory>>> GetEventCategories() =>
        Ok((await _bll.EventCategories.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Event Category.
    /// </summary>
    /// <param name="id">Event Category ID Value To Search For Event Category.</param>
    /// <returns>Event Category Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EventCategory), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventCategory>> GetEventCategory(Guid id)
    {
        var eventCategory = await _bll.EventCategories.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (eventCategory == null) return NotFound();
        
        return _mapper.Map(eventCategory)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Event Category In Database Layer.
    /// </summary>
    /// <param name="id">Event Category ID Value of Event Category To Be Updated.</param>
    /// <param name="eventCategory">Defines Event Category Value To Be Updated.</param>
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
    public async Task<IActionResult> PutEventCategory(Guid id, EventCategory eventCategory)
    {
        if (!id.Equals(eventCategory.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.EventCategories.Update(_mapper.Map(eventCategory)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Event Category Record In Database Layer.
    /// </summary>
    /// <param name="eventCategory">Object Value To Be Created In Database.</param>
    /// <returns>Created Event Category Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(EventCategory), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<ActionResult<EventCategory>> PostEventCategory(EventCategory eventCategory)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllEventCategory = _bll.EventCategories.Add(_mapper.Map(eventCategory)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetEventCategory", new
        {
            id = bllEventCategory.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllEventCategory);
    }

    /// <summary>
    /// Method Deletes Event Category In The Database Layer.
    /// </summary>
    /// <param name="id">Event Category ID Value of Event Category To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteEventCategory(Guid id)
    {
        // Try To Get Record From Database.
        var eventCategory = await _bll.EventCategories.FirstOrDefaultAsync(id);

        if (eventCategory == null) return NotFound();
        
        // Remove Existed Record.
        _bll.EventCategories.Remove(eventCategory);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}