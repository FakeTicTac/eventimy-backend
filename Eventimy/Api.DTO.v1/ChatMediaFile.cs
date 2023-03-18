using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Chat Media Files Implementation. Defines Specific Entity Rows for Chat Media Files. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatMediaFile : DomainEntityId
{
    /// <summary>
    /// Defines Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    public byte[]? MediaFile { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Chat Message ID.
    /// </summary>
    public Guid ChatMessageId { get; set; }

    /// <summary>
    /// Defines Chat Media File Belonging To The Chat ID.
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Defines Chat Media File Belonging To The Media File Type ID.
    /// </summary>
    public Guid MediaFileTypeId { get; set; }
}
