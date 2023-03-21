using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For User In Event Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class UserInEventController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// User In Event Mapper Connection Definition.
    /// </summary>
    private readonly UserInEventMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserInEventController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new UserInEventMapper(mapper);
    }


    /// <summary>
    /// Method Gets All User In Events.
    /// </summary>
    /// <returns>IEnumerable of Chats.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<UserInEvent>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserInEvent>>> GetUserInEvents() =>
        Ok((await _bll.UserInEvents.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets User In Event.
    /// </summary>
    /// <param name="id">User In Events ID Value To Search For User In Events.</param>
    /// <returns>User In Events Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserInEvent), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserInEvent>> GetUserInEvent(Guid id)
    {
        var userInEvent = await _bll.UserInEvents.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (userInEvent == null) return NotFound();
        
        return _mapper.Map(userInEvent)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of User In Event In Database Layer.
    /// </summary>
    /// <param name="id">User In Event ID Value of User In Event To Be Updated.</param>
    /// <param name="userInEvent">Defines User In Event Value To Be Updated.</param>
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
    public async Task<IActionResult> PutUserInEvent(Guid id, UserInEvent userInEvent)
    {
        if (!id.Equals(userInEvent.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.UserInEvents.Update(_mapper.Map(userInEvent)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates User In Event Record In Database Layer.
    /// </summary>
    /// <param name="userInEvent">Object Value To Be Created In Database.</param>
    /// <returns>Created User In Event Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(UserInEvent), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Chat>> PostUserInEvent(UserInEvent userInEvent)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllUserInEvent = _bll.UserInEvents.Add(_mapper.Map(userInEvent)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetUserInEvent", new
        {
            id = bllUserInEvent.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllUserInEvent);

    }

    /// <summary>
    /// Method Deletes User In Event In The Database Layer.
    /// </summary>
    /// <param name="id">User In Event ID Value of User In Event To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUserInEvent(Guid id)
    {
        // Try To Get Record From Database.
        var userInEvent = await _bll.UserInEvents.FirstOrDefaultAsync(id);

        if (userInEvent == null) return NotFound();
        
        // Remove Existed Record.
        _bll.UserInEvents.Remove(userInEvent);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}