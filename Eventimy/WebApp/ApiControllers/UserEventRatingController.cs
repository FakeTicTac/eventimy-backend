using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For User Event Rating Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class UserEventRatingController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// User Event Rating Mapper Connection Definition.
    /// </summary>
    private readonly UserEventRatingMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserEventRatingController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new UserEventRatingMapper(mapper);
    }


    /// <summary>
    /// Method Gets All User Event Ratings.
    /// </summary>
    /// <returns>IEnumerable of User Event Ratings.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<UserEventRating>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chat>>> GetUserEventRatings() =>
        Ok((await _bll.UserEventRatings.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets User Event Rating.
    /// </summary>
    /// <param name="id">User Event Rating ID Value To Search For User Event Rating.</param>
    /// <returns>User Event Rating Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserEventRating), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserEventRating>> GetUserEventRating(Guid id)
    {
        var userEventRating = await _bll.UserEventRatings.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (userEventRating == null) return NotFound();
        
        return _mapper.Map(userEventRating)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of User Event Rating In Database Layer.
    /// </summary>
    /// <param name="id">User Event Rating ID Value of User Event Rating To Be Updated.</param>
    /// <param name="userEventRating">Defines User Event Rating Value To Be Updated.</param>
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
    public async Task<IActionResult> PutUserEventRating(Guid id, UserEventRating userEventRating)
    {
        if (!id.Equals(userEventRating.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.UserEventRatings.Update(_mapper.Map(userEventRating)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates User Event Rating Record In Database Layer.
    /// </summary>
    /// <param name="userEventRating">Object Value To Be Created In Database.</param>
    /// <returns>Created User Event Rating Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(UserEventRating), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<UserEventRating>> PosUserEventRating(UserEventRating userEventRating)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllUserEventRating = _bll.UserEventRatings.Add(_mapper.Map(userEventRating)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetUserEventRatings", new
        {
            id = bllUserEventRating.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllUserEventRating);
    }

    /// <summary>
    /// Method Deletes User Event Rating In The Database Layer.
    /// </summary>
    /// <param name="id">User Event Rating ID Value of User Event Rating To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUserEventRating(Guid id)
    {
        // Try To Get Record From Database.
        var userEventRating = await _bll.UserEventRatings.FirstOrDefaultAsync(id);

        if (userEventRating == null) return NotFound();
        
        // Remove Existed Record.
        _bll.UserEventRatings.Remove(userEventRating);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}