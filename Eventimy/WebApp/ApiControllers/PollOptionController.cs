using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Poll Option Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class PollOptionController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Poll Option Mapper Connection Definition.
    /// </summary>
    private readonly PollOptionMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollOptionController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new PollOptionMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Poll Options.
    /// </summary>
    /// <returns>IEnumerable of Poll Options.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Chat>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chat>>> GetPollOptions() =>
        Ok((await _bll.PollOptions.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Poll Option.
    /// </summary>
    /// <param name="id">Poll Option ID Value To Search For Poll Option.</param>
    /// <returns>Poll Option Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PollOption), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PollOption>> GetPollOption(Guid id)
    {
        var pollOption = await _bll.PollOptions.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (pollOption == null) return NotFound();
        
        return _mapper.Map(pollOption)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Poll Option In Database Layer.
    /// </summary>
    /// <param name="id">Poll Option ID Value of Poll Option To Be Updated.</param>
    /// <param name="pollOption">Defines Poll Option Value To Be Updated.</param>
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
    public async Task<IActionResult> PutPollOption(Guid id, PollOption pollOption)
    {
        if (!id.Equals(pollOption.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.PollOptions.Update(_mapper.Map(pollOption)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Poll Option Record In Database Layer.
    /// </summary>
    /// <param name="pollOption">Object Value To Be Created In Database.</param>
    /// <returns>Created Poll Option Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(PollOption), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<PollOption>> PostPollOption(PollOption pollOption)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllPollOption = _bll.PollOptions.Add(_mapper.Map(pollOption)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetPollOption", new
        {
            id = bllPollOption.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllPollOption);
    }

    /// <summary>
    /// Method Deletes Poll Option In The Database Layer.
    /// </summary>
    /// <param name="id">Chat ID Value of Poll Option To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePollOption(Guid id)
    {
        // Try To Get Record From Database.
        var pollOption = await _bll.PollOptions.FirstOrDefaultAsync(id);

        if (pollOption == null) return NotFound();
        
        // Remove Existed Record.
        _bll.PollOptions.Remove(pollOption);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}