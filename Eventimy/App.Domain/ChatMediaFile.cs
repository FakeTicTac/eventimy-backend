using Base.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Chat Media Files Implementation. Defines Specific Entity Rows for Chat Media Files. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatMediaFile : DomainEntityMetaId
{
    /// <summary>
    /// Defines Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength]
    public byte[]? MediaFile { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Chat Message ID.
    /// </summary>
    public Guid ChatMessageId { get; set; }
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Chat Message.
    /// </summary>
    public ChatMessage? ChatMessage { get; set; }
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Chat ID.
    /// </summary>
    public Guid ChatId { get; set; }
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Chat.
    /// </summary>
    public Chat? Chat { get; set; }
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Media File Type ID.
    /// </summary>
    public Guid MediaFileTypeId { get; set; }
    
    /// <summary>
    /// Defines Chat Media File Belonging To The Media File Type.
    /// </summary>
    public MediaFileType? MediaFileType { get; set; }
}
