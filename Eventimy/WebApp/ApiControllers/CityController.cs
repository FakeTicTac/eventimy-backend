using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For City Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class CityController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// City Mapper Connection Definition.
    /// </summary>
    private readonly CityMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CityController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new CityMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Cities.
    /// </summary>
    /// <returns>IEnumerable of Cities.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<City>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Chat>>> GetCities() =>
        Ok((await _bll.Cities.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets City.
    /// </summary>
    /// <param name="id">City ID Value To Search For City.</param>
    /// <returns>City Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<City>> GetCity(Guid id)
    {
        var city = await _bll.Cities.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (city == null) return NotFound();
        
        return _mapper.Map(city)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of City In Database Layer.
    /// </summary>
    /// <param name="id">City ID Value of City To Be Updated.</param>
    /// <param name="city">Defines City Value To Be Updated.</param>
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> PutCity(Guid id, City city)
    {
        if (!id.Equals(city.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.Cities.Update(_mapper.Map(city)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates City Record In Database Layer.
    /// </summary>
    /// <param name="city">Object Value To Be Created In Database.</param>
    /// <returns>Created City Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<ActionResult<Chat>> PostCity(City city)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllCity = _bll.Cities.Add(_mapper.Map(city)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetCity", new
        {
            id = bllCity.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllCity);

    }

    /// <summary>
    /// Method Deletes City In The Database Layer.
    /// </summary>
    /// <param name="id">City ID Value of City To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> DeleteCity(Guid id)
    {
        // Try To Get Record From Database.
        var city = await _bll.Cities.FirstOrDefaultAsync(id);

        if (city == null) return NotFound();
        
        // Remove Existed Record.
        _bll.Cities.Remove(city);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}