using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO;


/// <summary>
/// Application Chat Poll Implementation. Defines Specific Entity Rows for Chat Poll. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class ChatPoll : DomainEntityId
{
    /// <summary>
    /// Defines Chat Poll Topic Title Entity Row.
    /// </summary>
    public LanguageString Title { get; set; } = new();

    /// <summary>
    /// Defines Chat Poll Anonymous Mode (Does Voted Users Shown?) Entity Row.
    /// </summary>
    public bool IsAnonymous { get; set; }
    
    /// <summary>
    /// Defines Chat Poll Answer Chose Mode (Can Multiple Answers Be Chosen?) Entity Row.
    /// </summary>
    public bool IsMultipleChoice { get; set; }
    
    /// <summary>
    /// Defines Chat Poll Answer Change Mode (Can Chosen Answers Be Changed?) Entity Row.
    /// </summary>
    public bool CanChangeVote { get; set; }
    
    /// <summary>
    /// Defines Chat Poll Answering Time Limit (Can Be Answered Only For Some Amount Of Time) Entity Row.
    /// </summary>
    public bool IsLimitedTime { get; set; }
    
    /// <summary>
    /// Defines Chat Poll Answering Time Limit.
    /// </summary>
    public DateTime? EndTime { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Chat Poll Belonging To The Chat ID.
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Defines Chat Poll Belonging To The Chat Participant ID.
    /// </summary>
    public Guid ChatParticipantId { get; set; }
}