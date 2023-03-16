using Base.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using App.Contracts.DAL.Repositories.Identity;


namespace App.Contracts.DAL;


/// <summary>
/// App Specific Unit of Work Design. Defines Repos That Should Be Implemented.
/// </summary>
public interface IAppUnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Chat Media Files.
    /// </summary>
    IChatMediaFileRepository ChatMediaFiles { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Chat Messages.
    /// </summary>
    IChatMessageRepository ChatMessages { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Chat Participants.
    /// </summary>
    IChatParticipantRepository ChatParticipants { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Chat Polls.
    /// </summary>
    IChatPollRepository ChatPolls { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Chats.
    /// </summary>
    IChatRepository Chats { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Cities.
    /// </summary>
    ICityRepository Cities { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing Countries.
    /// </summary>
    ICountryRepository Countries { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing Event Categories.
    /// </summary>
    IEventCategoryRepository EventCategories { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing Event Media Files.
    /// </summary>
    IEventMediaFileRepository EventMediaFiles { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Event Reactions.
    /// </summary>
    IEventReactionRepository EventReactions { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Events.
    /// </summary>
    IEventRepository Events { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing Media File Types.
    /// </summary>
    IMediaFileTypeRepository MediaFileTypes { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing Performers.
    /// </summary>
    IPerformerRepository Performers { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Performer Types.
    /// </summary>
    IPerformerTypeRepository PerformerTypes { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Poll Answers.
    /// </summary>
    IPollAnswerRepository PollAnswers { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Poll Options.
    /// </summary>
    IPollOptionRepository PollOptions { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Reaction Types.
    /// </summary>
    IReactionTypeRepository ReactionTypes { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing Subscriptions.
    /// </summary>
    ISubscriptionRepository Subscriptions { get; }

    /// <summary>
    /// Data Access Layer Repository Definition For Storing User Event Ratings.
    /// </summary>
    IUserEventRatingRepository UserEventRatings { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing User In Events.
    /// </summary>
    IUserInEventRepository UserInEvents { get; }


    // Identity Related Only
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Refresh Tokens.
    /// </summary>
    IRefreshTokenRepository RefreshTokens { get; }
}