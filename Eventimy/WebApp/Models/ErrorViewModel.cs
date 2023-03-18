namespace WebApp.Models;


/// <summary>
/// Model For Error Happened in The App Displaying.
/// </summary>
public class ErrorViewModel
{
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    /// <summary>
    /// Defines Request ID.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Shows Request ID.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}