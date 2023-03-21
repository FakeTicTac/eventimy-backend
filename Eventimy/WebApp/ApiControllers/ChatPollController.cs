using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Chat Poll Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class ChatPollController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Chat Poll Mapper Connection Definition.
    /// </summary>
    private readonly ChatPollMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatPollController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new ChatPollMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Chat Polls.
    /// </summary>
    /// <returns>IEnumerable of Chat Polls.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ChatPoll>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ChatPoll>>> GetChatPolls() =>
        Ok((await _bll.ChatPolls.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Chat Poll.
    /// </summary>
    /// <param name="id">Chat Poll ID Value To Search For Chat Poll.</param>
    /// <returns>Chat Poll Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ChatPoll>> GetChatPoll(Guid id)
    {
        var chatPoll = await _bll.ChatPolls.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (chatPoll == null) return NotFound();
        
        return _mapper.Map(chatPoll)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Chat Poll In Database Layer.
    /// </summary>
    /// <param name="id">Chat Poll ID Value of Chat Poll To Be Updated.</param>
    /// <param name="chatPoll">Defines Chat Poll Value To Be Updated.</param>
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
    public async Task<IActionResult> PutChatPoll(Guid id, ChatPoll chatPoll)
    {
        if (!id.Equals(chatPoll.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.ChatPolls.Update(_mapper.Map(chatPoll)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Chat Poll Record In Database Layer.
    /// </summary>
    /// <param name="chatPoll">Object Value To Be Created In Database.</param>
    /// <returns>Created ChatPoll Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(ChatPoll), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ChatPoll>> PostChatPoll(ChatPoll chatPoll)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllChatPoll = _bll.ChatPolls.Add(_mapper.Map(chatPoll)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetChatPoll", new
        {
            id = bllChatPoll.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllChatPoll);

    }

    /// <summary>
    /// Method Deletes Chat Poll In The Database Layer.
    /// </summary>
    /// <param name="id">Chat Poll ID Value of Chat Poll To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChatPoll(Guid id)
    {
        // Try To Get Record From Database.
        var chatPoll = await _bll.ChatPolls.FirstOrDefaultAsync(id);

        if (chatPoll == null) return NotFound();
        
        // Remove Existed Record.
        _bll.ChatPolls.Remove(chatPoll);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}