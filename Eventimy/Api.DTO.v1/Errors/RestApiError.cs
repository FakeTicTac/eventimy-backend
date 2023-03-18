using System.Net;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1.Errors;


/// <summary>
/// Application API Error Response Implementation. Defines Specific Rows for API Error Response. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class RestApiError
{
    /// <summary>
    /// Defines Type Of Of Error.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Defines Title Of Of Error. (Whats' Gone Wrong)
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// Defines Status Code To Be Sent.
    /// </summary>
    public HttpStatusCode Status { get; set; }

    /// <summary>
    /// Defines Trace ID Of Error.
    /// </summary>
    public string? TraceId { get; set; }

    /// <summary>
    /// Defines Collection Of Happened Errors.
    /// </summary>
    // ReSharper disable once CollectionNeverQueried.Global
    public Dictionary<string, List<string>> Errors { get; set; } = new();
}