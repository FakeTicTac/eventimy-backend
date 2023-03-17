using Base.Contracts.BLL;
using App.Contracts.BLL.Services;
using App.Contracts.BLL.Services.Identity;


namespace App.Contracts.BLL;


/// <summary>
/// App Specific Business Logic Design. Defines Services That Should Be Implemented.
/// </summary>
public interface IAppBusinessLogic : IBusinessLogic
{
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Chat Media Files.
    /// </summary>
    IChatMediaFileService ChatMediaFiles { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Chat Messages.
    /// </summary>
    IChatMessageService ChatMessages { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Chat Participants.
    /// </summary>
    IChatParticipantService ChatParticipants { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Chat Polls.
    /// </summary>
    IChatPollService ChatPolls { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Chats.
    /// </summary>
    IChatService Chats { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Cities.
    /// </summary>
    ICityService Cities { get; }

    /// <summary>
    /// Business Logic Layer Service Definition For Storing Countries.
    /// </summary>
    ICountryService Countries { get; }

    /// <summary>
    /// Business Logic Layer Service Definition For Storing Event Categories.
    /// </summary>
    IEventCategoryService EventCategories { get; }

    /// <summary>
    /// Business Logic Layer Service Definition For Storing Event Media Files.
    /// </summary>
    IEventMediaFileService EventMediaFiles { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Event Reactions.
    /// </summary>
    IEventReactionService EventReactions { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Events.
    /// </summary>
    IEventService Events { get; }

    /// <summary>
    /// Business Logic Layer Service Definition For Storing Media File Types.
    /// </summary>
    IMediaFileTypeService MediaFileTypes { get; }

    /// <summary>
    /// Business Logic Layer Service Definition For Storing Performers.
    /// </summary>
    IPerformerService Performers { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Performer Types.
    /// </summary>
    IPerformerTypeService PerformerTypes { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Poll Answers.
    /// </summary>
    IPollAnswerService PollAnswers { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Poll Options.
    /// </summary>
    IPollOptionService PollOptions { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Reaction Types.
    /// </summary>
    IReactionTypeService ReactionTypes { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Subscriptions.
    /// </summary>
    ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// Business Logic Layer Service Definition For Storing User Event Ratings.
    /// </summary>
    IUserEventRatingService UserEventRatings { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing User In Events.
    /// </summary>
    IUserInEventService UserInEvents { get; }


    // Identity Related Only
    
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing User in Collections.
    /// </summary>
    IRefreshTokenService RefreshTokens { get; }
}