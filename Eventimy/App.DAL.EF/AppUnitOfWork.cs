using AutoMapper;
using Base.DAL.EF;
using App.Contracts.DAL;
using App.DAL.EF.Repositories;
using App.Contracts.DAL.Repositories;
using App.DAL.EF.Repositories.Identity;
using App.Contracts.DAL.Repositories.Identity;


namespace App.DAL.EF;


/// <summary>
/// App Specific Unit of Work Design Implementation - Implements All Repositories.
/// </summary>
public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
{

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Chat Media Files.
    /// </summary>
    public IChatMediaFileRepository ChatMediaFiles =>
            GetRepository(() => new ChatMediaFileRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Chat Messages.
    /// </summary>
    public IChatMessageRepository ChatMessages =>
            GetRepository(() => new ChatMessageRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Chat Participants.
    /// </summary>
    public IChatParticipantRepository ChatParticipants =>
            GetRepository(() => new ChatParticipantRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Chat Polls.
    /// </summary>
    public IChatPollRepository ChatPolls =>
            GetRepository(() => new ChatPollRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Chats.
    /// </summary>
    public IChatRepository Chats =>
            GetRepository(() => new ChatRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Cities.
    /// </summary>
    public ICityRepository Cities =>
            GetRepository(() => new CityRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Countries.
    /// </summary>
    public ICountryRepository Countries =>
            GetRepository(() => new CountryRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Event Categories.
    /// </summary>
    public IEventCategoryRepository EventCategories =>
            GetRepository(() => new EventCategoryRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Event Media Files.
    /// </summary>
    public IEventMediaFileRepository EventMediaFiles =>
            GetRepository(() => new EventMediaFileRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Event Reactions.
    /// </summary>
    public IEventReactionRepository EventReactions =>
            GetRepository(() => new EventReactionRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Events.
    /// </summary>
    public IEventRepository Events =>
            GetRepository(() => new EventRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Media File Types.
    /// </summary>
    public IMediaFileTypeRepository MediaFileTypes=>
            GetRepository(() => new MediaFileTypeRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Performers.
    /// </summary>
    public IPerformerRepository Performers =>
            GetRepository(() => new PerformerRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Performer Types.
    /// </summary>
    public IPerformerTypeRepository PerformerTypes =>
            GetRepository(() => new PerformerTypeRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Poll Answers.
    /// </summary>
    public IPollAnswerRepository PollAnswers =>
            GetRepository(() => new PollAnswerRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Poll Options.
    /// </summary>
    public IPollOptionRepository PollOptions =>
            GetRepository(() => new PollOptionRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Reaction Types.
    /// </summary>
    public IReactionTypeRepository ReactionTypes =>
            GetRepository(() => new ReactionTypeRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Subscriptions.
    /// </summary>
    public ISubscriptionRepository Subscriptions =>
            GetRepository(() => new SubscriptionRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing User Event Ratings.
    /// </summary>
    public IUserEventRatingRepository UserEventRatings =>
            GetRepository(() => new UserEventRatingRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing User In Events.
    /// </summary>
    public IUserInEventRepository UserInEvents =>
            GetRepository(() => new UserInEventRepository(UowDbContext, Mapper));


    // Identity Related Only


    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Refresh Tokens.
    /// </summary>
    public IRefreshTokenRepository RefreshTokens => 
            GetRepository(() => new RefreshTokenRepository(UowDbContext, Mapper));
    
    
    /// <summary>
    /// Defines Connection to The Mapper Profile.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly IMapper Mapper;


    /// <summary>
    /// App Specific Unit of Work Constructor. Defines Connection to The Database Layer.
    /// </summary>
    /// <param name="uowDbContext">Defines Connection to The Database Layer.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext) => Mapper = mapper;
}