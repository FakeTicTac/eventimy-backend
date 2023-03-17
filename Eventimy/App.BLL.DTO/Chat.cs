using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Chat Implementation. Defines Specific Entity Rows for Chat.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class Chat : DomainEntityId
{
    /// <summary>
    /// Defines Chat Title Entity Row.
    /// </summary>
    public LanguageString Title { get; set; } = new();

    /// <summary>
    /// Defines Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    public byte[]? ThumbNailImage { get; set; }


    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Belonging To The Event ID.
    /// </summary>
    public Guid? EventId { get; set; }
    
    /// <summary>
    /// Defines Chat Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
}
