using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Poll Option Implementation. Defines Specific Entity Rows for Poll Option. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class PollOption : DomainEntityMetaId
{
    /// <summary>
    /// Defines Poll Option Value To Be Chosen By User Entity Row.
    /// </summary>
    public string? Value { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Poll Option Belonging To The Chat Poll ID.
    /// </summary>
    public Guid ChatPollId { get; set; }
    
    /// <summary>
    /// Defines Poll Option Belonging To The Chat Poll.
    /// </summary>
    public ChatPoll? ChatPoll { get; set; }
    
    /// <summary>
    /// Defines All Related To Poll Option Poll Answers.
    /// </summary>
    public ICollection<PollAnswer>? PollAnswers { get; set; }
}