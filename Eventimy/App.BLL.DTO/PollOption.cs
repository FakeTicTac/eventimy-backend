using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Poll Option Implementation. Defines Specific Entity Rows for Poll Option. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PollOption : DomainEntityId
{
    /// <summary>
    /// Defines Poll Option Value To Be Chosen By User Entity Row.
    /// </summary>
    public LanguageString Value { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Poll Option Belonging To The Chat Poll ID.
    /// </summary>
    public Guid ChatPollId { get; set; }
}