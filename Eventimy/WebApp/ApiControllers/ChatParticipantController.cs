using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Chat Participant Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class ChatParticipantController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Chat Participant Mapper Connection Definition.
    /// </summary>
    private readonly ChatParticipantMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatParticipantController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new ChatParticipantMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Chat Participants.
    /// </summary>
    /// <returns>IEnumerable of Chat Participants.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ChatParticipant>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ChatParticipant>>> GetChatParticipants() =>
        Ok((await _bll.ChatParticipants.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Chat Participant.
    /// </summary>
    /// <param name="id">Chat Participant ID Value To Search For Chat Participant.</param>
    /// <returns>Chat Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ChatParticipant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ChatParticipant>> GetChatParticipant(Guid id)
    {
        var chatParticipant = await _bll.ChatParticipants.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (chatParticipant == null) return NotFound();
        
        return _mapper.Map(chatParticipant)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Chat Participant In Database Layer.
    /// </summary>
    /// <param name="id">Chat Participant ID Value of Chat Participant To Be Updated.</param>
    /// <param name="chatParticipant">Defines Chat Participant Value To Be Updated.</param>
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
    public async Task<IActionResult> PutChatParticipant(Guid id, ChatParticipant chatParticipant)
    {
        if (!id.Equals(chatParticipant.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.ChatParticipants.Update(_mapper.Map(chatParticipant)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Chat Participant Record In Database Layer.
    /// </summary>
    /// <param name="chatParticipant">Object Value To Be Created In Database.</param>
    /// <returns>Created Chat Participant Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(ChatParticipant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ChatParticipant>> PostChat(ChatParticipant chatParticipant)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllChatParticipant = _bll.ChatParticipants.Add(_mapper.Map(chatParticipant)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetChatParticipant", new
        {
            id = bllChatParticipant.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllChatParticipant);
    }

    /// <summary>
    /// Method Deletes Chat Participant In The Database Layer.
    /// </summary>
    /// <param name="id">Chat Participant ID Value of Chat Participant To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChatParticipant(Guid id)
    {
        // Try To Get Record From Database.
        var chatParticipant = await _bll.ChatParticipants.FirstOrDefaultAsync(id);

        if (chatParticipant == null) return NotFound();
        
        // Remove Existed Record.
        _bll.ChatParticipants.Remove(chatParticipant);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}