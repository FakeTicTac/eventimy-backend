using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Media File Type Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class MediaFileTypeController : ControllerBase 
{
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Media File Type Mapper Connection Definition.
    /// </summary>
    private readonly MediaFileTypeMapper _mapper;

    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public MediaFileTypeController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new MediaFileTypeMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Media File Types.
    /// </summary>
    /// <returns>IEnumerable of Media File Types.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<MediaFileType>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MediaFileType>>> GetMediaFileTypes() =>
        Ok((await _bll.MediaFileTypes.GetAllAsync()).Select(x => _mapper.Map(x)));
    
    
    /// <summary>
    /// Method Gets Media File Type.
    /// </summary>
    /// <param name="id">Media File Type ID Value To Search For Media File Type.</param>
    /// <returns>Media File Type Object.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(MediaFileType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MediaFileType>> GetMediaFileType(Guid id)
    {
        var mediaFileType = await _bll.MediaFileTypes.FirstOrDefaultAsync(id);

        // Check If Exist In Database.
        if (mediaFileType == null) return NotFound();
        
        return _mapper.Map(mediaFileType)!;
    }
    
    
    /// <summary>
    /// Method Updates Record of Media File Type In Database Layer.
    /// </summary>
    /// <param name="id">Media File Type ID Value of Media File Type To Be Updated.</param>
    /// <param name="mediaFileType">Defines Media File Type Value To Be Updated.</param>
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
    public async Task<IActionResult> PutMediaFileType(Guid id, MediaFileType mediaFileType)
    {
        if (!id.Equals(mediaFileType.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.MediaFileTypes.Update(_mapper.Map(mediaFileType)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Media File Type Record In Database Layer.
    /// </summary>
    /// <param name="mediaFileType">Object Value To Be Created In Database.</param>
    /// <returns>Created Media File Type Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(MediaFileType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<ActionResult<MediaFileType>> PostMediaFileType(MediaFileType mediaFileType)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllMediaFileType = _bll.MediaFileTypes.Add(_mapper.Map(mediaFileType)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetMediaFileType", new
        {
            id = bllMediaFileType.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllMediaFileType);
    }

    /// <summary>
    /// Method Deletes Media File Type In The Database Layer.
    /// </summary>
    /// <param name="id">Media File Type ID Value of Media File Type To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteMediaFileType(Guid id)
    {
        // Try To Get Record From Database.
        var mediaFileType = await _bll.MediaFileTypes.FirstOrDefaultAsync(id);

        if (mediaFileType == null) return NotFound();
        
        // Remove Existed Record.
        _bll.MediaFileTypes.Remove(mediaFileType);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}