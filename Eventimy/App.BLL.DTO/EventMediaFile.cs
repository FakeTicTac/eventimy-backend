using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Event Media Files Implementation. Defines Specific Entity Rows for Event Media Files. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class EventMediaFile : DomainEntityId
{
    /// <summary>
    /// Defines Media File Location on The Server Side Entity Row.
    /// </summary>
    public byte[]? MediaFile { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Event Media File Belonging To The Event ID.
    /// </summary>
    public Guid EventId { get; set; }

    /// <summary>
    /// Defines Event Media File Belonging To The Media File Type ID.
    /// </summary>
    public Guid MediaFileTypeId { get; set; }
}