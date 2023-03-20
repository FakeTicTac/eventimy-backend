using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Subscription Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class SubscriptionController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Subscription Mapper Connection Definition.
    /// </summary>
    private readonly SubscriptionMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public SubscriptionController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new SubscriptionMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Subscriptions.
    /// </summary>
    /// <returns>IEnumerable of Subscriptions.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Subscription>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions() =>
        Ok((await _bll.Subscriptions.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Subscription.
    /// </summary>
    /// <param name="id">Subscription ID Value To Search For Subscription.</param>
    /// <returns>Subscription Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Subscription>> GetSubscription(Guid id)
    {
        var subscription = await _bll.Subscriptions.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (subscription == null) return NotFound();
        
        return _mapper.Map(subscription)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Subscription In Database Layer.
    /// </summary>
    /// <param name="id">Subscription ID Value of Subscription To Be Updated.</param>
    /// <param name="subscription">Defines Subscription Value To Be Updated.</param>
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
    public async Task<IActionResult> PutSubscription(Guid id, Subscription subscription)
    {
        if (!id.Equals(subscription.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.Subscriptions.Update(_mapper.Map(subscription)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Subscription Record In Database Layer.
    /// </summary>
    /// <param name="subscription">Object Value To Be Created In Database.</param>
    /// <returns>Created Subscription Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Chat), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Subscription>> PostChat(Subscription subscription)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllSubscription = _bll.Subscriptions.Add(_mapper.Map(subscription)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetSubscription", new
        {
            id = bllSubscription.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllSubscription);
    }

    /// <summary>
    /// Method Deletes Subscription In The Database Layer.
    /// </summary>
    /// <param name="id">Subscription ID Value of Subscription To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSubscription(Guid id)
    {
        // Try To Get Record From Database.
        var subscription = await _bll.Subscriptions.FirstOrDefaultAsync(id);

        if (subscription == null) return NotFound();
        
        // Remove Existed Record.
        _bll.Subscriptions.Remove(subscription);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}