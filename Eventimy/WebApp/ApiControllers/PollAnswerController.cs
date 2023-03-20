using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Poll Answer Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class PollController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Poll Answer Mapper Connection Definition.
    /// </summary>
    private readonly PollAnswerMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public PollController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new PollAnswerMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Poll Answers.
    /// </summary>
    /// <returns>IEnumerable of Poll Answers.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<PollAnswer>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PollAnswer>>> GetPollAnswers() =>
        Ok((await _bll.PollAnswers.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets PollAnswer.
    /// </summary>
    /// <param name="id">PollAnswer ID Value To Search For PollAnswer.</param>
    /// <returns>PollAnswer Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PollAnswer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PollAnswer>> GetPollAnswer(Guid id)
    {
        var pollAnswer = await _bll.PollAnswers.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (pollAnswer == null) return NotFound();
        
        return _mapper.Map(pollAnswer)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Poll Answer In Database Layer.
    /// </summary>
    /// <param name="id">Poll Answer ID Value of Poll Answer To Be Updated.</param>
    /// <param name="chat">Defines Poll Answer Value To Be Updated.</param>
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
    public async Task<IActionResult> PutPollAnswer(Guid id, PollAnswer pollAnswer)
    {
        if (!id.Equals(pollAnswer.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.PollAnswers.Update(_mapper.Map(pollAnswer)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Poll Answer Record In Database Layer.
    /// </summary>
    /// <param name="pollAnswer">Object Value To Be Created In Database.</param>
    /// <returns>Created Poll Answer Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(PollAnswer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<PollAnswer>> PostPollAnswer(PollAnswer pollAnswer)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllPollAnswer = _bll.PollAnswers.Add(_mapper.Map(pollAnswer)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetPollAnswer", new
        {
            id = bllPollAnswer.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllPollAnswer);

    }

    /// <summary>
    /// Method Deletes Poll Answer In The Database Layer.
    /// </summary>
    /// <param name="id">Poll Answer ID Value of Poll Answer To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePollAnswer(Guid id)
    {
        // Try To Get Record From Database.
        var pollAnswer = await _bll.PollAnswers.FirstOrDefaultAsync(id);

        if (pollAnswer == null) return NotFound();
        
        // Remove Existed Record.
        _bll.PollAnswers.Remove(pollAnswer);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}