using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Chat Message Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class ChatMessageController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Chat Message Mapper Connection Definition.
    /// </summary>
    private readonly ChatMessageMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMessageController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new ChatMessageMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Chat Messages.
    /// </summary>
    /// <returns>IEnumerable of Chat Messages.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ChatMessage>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ChatMessage>>> GetChatMessages() =>
        Ok((await _bll.ChatMessages.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Chat Message.
    /// </summary>
    /// <param name="id">Chat Message ID Value To Search For Chat Message.</param>
    /// <returns>Chat Message Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ChatMessage), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ChatMessage>> GetChatMessage(Guid id)
    {
        var chatMessage = await _bll.ChatMessages.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (chatMessage == null) return NotFound();
        
        return _mapper.Map(chatMessage)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Chat Message In Database Layer.
    /// </summary>
    /// <param name="id">Chat Message ID Value of Chat Message To Be Updated.</param>
    /// <param name="chatMessage">Defines Chat Message Value To Be Updated.</param>
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
    public async Task<IActionResult> PutChatMessage(Guid id, ChatMessage chatMessage)
    {
        if (!id.Equals(chatMessage.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.ChatMessages.Update(_mapper.Map(chatMessage)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Chat Message Record In Database Layer.
    /// </summary>
    /// <param name="chatMessage">Object Value To Be Created In Database.</param>
    /// <returns>Created Chat Message Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(ChatMessage), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ChatMessage>> PostChat(ChatMessage chatMessage)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllChatMessage = _bll.ChatMessages.Add(_mapper.Map(chatMessage)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetChatMessage", new
        {
            id = bllChatMessage.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllChatMessage);

    }

    /// <summary>
    /// Method Deletes Chat Message In The Database Layer.
    /// </summary>
    /// <param name="id">Chat Message ID Value of Chat Message To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChatMessage(Guid id)
    {
        // Try To Get Record From Database.
        var chatMessage = await _bll.ChatMessages.FirstOrDefaultAsync(id);

        if (chatMessage == null) return NotFound();
        
        // Remove Existed Record.
        _bll.ChatMessages.Remove(chatMessage);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}