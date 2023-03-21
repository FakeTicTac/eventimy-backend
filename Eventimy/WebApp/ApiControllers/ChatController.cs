using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


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
public class ChatController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Chat Mapper Connection Definition.
    /// </summary>
    private readonly ChatMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new ChatMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Chats.
    /// </summary>
    /// <returns>IEnumerable of Chats.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Chat>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chat>>> GetChats() =>
        Ok((await _bll.Chats.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Chat.
    /// </summary>
    /// <param name="id">Chat ID Value To Search For Chat.</param>
    /// <returns>Chat Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Chat>> GetChat(Guid id)
    {
        var chat = await _bll.Chats.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (chat == null) return NotFound();
        
        return _mapper.Map(chat)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Chat In Database Layer.
    /// </summary>
    /// <param name="id">Chat ID Value of Chat To Be Updated.</param>
    /// <param name="chat">Defines Chat Value To Be Updated.</param>
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
    public async Task<IActionResult> PutChat(Guid id, Chat chat)
    {
        if (!id.Equals(chat.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.Chats.Update(_mapper.Map(chat)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Chat Record In Database Layer.
    /// </summary>
    /// <param name="chat">Object Value To Be Created In Database.</param>
    /// <returns>Created Chat Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Chat>> PostChat(Chat chat)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllChat = _bll.Chats.Add(_mapper.Map(chat)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetChat", new
        {
            id = bllChat.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllChat);

    }

    /// <summary>
    /// Method Deletes Chat In The Database Layer.
    /// </summary>
    /// <param name="id">Chat ID Value of Chat To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChat(Guid id)
    {
        // Try To Get Record From Database.
        var chat = await _bll.Chats.FirstOrDefaultAsync(id);

        if (chat == null) return NotFound();
        
        // Remove Existed Record.
        _bll.Chats.Remove(chat);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}