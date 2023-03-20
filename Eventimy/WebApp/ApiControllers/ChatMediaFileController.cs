using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Chat Media File Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class ChatMediaFileController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Chat Media File Mapper Connection Definition.
    /// </summary>
    private readonly ChatMediaFileMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public ChatMediaFileController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new ChatMediaFileMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Chat Media Files.
    /// </summary>
    /// <returns>IEnumerable of Chat Media Files.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ChatMediaFile>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ChatMediaFile>>> GetChatMediaFiles() =>
        Ok((await _bll.ChatMediaFiles.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Chat Media File.
    /// </summary>
    /// <param name="id">Chat Media File ID Value To Search For Chat Media File.</param>
    /// <returns>Chat Media File Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ChatMediaFile), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ChatMediaFile>> GetChatMediaFile(Guid id)
    {
        var chatMediaFile = await _bll.ChatMediaFiles.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (chatMediaFile == null) return NotFound();
        
        return _mapper.Map(chatMediaFile)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Chat Media File In Database Layer.
    /// </summary>
    /// <param name="id">Chat Media File ID Value of Chat Media File To Be Updated.</param>
    /// <param name="chatMediaFile">Defines Chat Media File Value To Be Updated.</param>
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
    public async Task<IActionResult> PutChatMediaFile(Guid id, ChatMediaFile chatMediaFile)
    {
        if (!id.Equals(chatMediaFile.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.ChatMediaFiles.Update(_mapper.Map(chatMediaFile)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Chat Media File Record In Database Layer.
    /// </summary>
    /// <param name="chatMediaFile">Object Value To Be Created In Database.</param>
    /// <returns>Created Chat Media File Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ChatMediaFile>> PostChatMediaFile(ChatMediaFile chatMediaFile)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllChatMediaFile = _bll.ChatMediaFiles.Add(_mapper.Map(chatMediaFile)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetChatMediaFiles", new
        {
            id = bllChatMediaFile.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllChatMediaFile);

    }

    /// <summary>
    /// Method Deletes Chat Media File In The Database Layer.
    /// </summary>
    /// <param name="id">Chat Media File ID Value of Chat Media File To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChatMediaFile(Guid id)
    {
        // Try To Get Record From Database.
        var chatMediaFile = await _bll.ChatMediaFiles.FirstOrDefaultAsync(id);

        if (chatMediaFile == null) return NotFound();
        
        // Remove Existed Record.
        _bll.ChatMediaFiles.Remove(chatMediaFile);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}