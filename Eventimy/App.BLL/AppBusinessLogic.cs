using Base.BLL;
using AutoMapper;
using App.BLL.Services;
using App.Contracts.DAL;
using App.Contracts.BLL;
using App.BLL.Services.Identity;
using App.Contracts.BLL.Services;
using App.Contracts.BLL.Services.Identity;


 namespace App.BLL;


/// <summary>
/// App Specific Business Logic Design Implementation - Implements All Services.
/// </summary>
public class AppBusinessLogic : BaseBusinessLogic<IAppUnitOfWork>, IAppBusinessLogic
{
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Chat Media Files.
    /// </summary>
    public IChatMediaFileService ChatMediaFiles =>
        GetService<IChatMediaFileService>(() => new ChatMediaFileService(Uow, Uow.ChatMediaFiles, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Chat Messages.
    /// </summary>
    public IChatMessageService ChatMessages =>
        GetService<IChatMessageService>(() => new ChatMessageService(Uow, Uow.ChatMessages, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Chat Participants.
    /// </summary>
    public IChatParticipantService ChatParticipants =>
        GetService<IChatParticipantService>(() => new ChatParticipantService(Uow, Uow.ChatParticipants, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Chat Polls.
    /// </summary>
    public IChatPollService ChatPolls =>
        GetService<IChatPollService>(() => new ChatPollService(Uow, Uow.ChatPolls, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Chats.
    /// </summary>
    public IChatService Chats =>
        GetService<IChatService>(() => new ChatService(Uow, Uow.Chats, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Cities.
    /// </summary>
    public ICityService Cities =>
        GetService<ICityService>(() => new CityService(Uow, Uow.Cities, Mapper));

    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Countries.
    /// </summary>
    public ICountryService Countries =>
        GetService<ICountryService>(() => new CountryService(Uow, Uow.Countries, Mapper));

    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Event Categories.
    /// </summary>
    public IEventCategoryService EventCategories =>
        GetService<IEventCategoryService>(() => new EventCategoryService(Uow, Uow.EventCategories, Mapper));

    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Event Media Files.
    /// </summary>
    public IEventMediaFileService EventMediaFiles =>
        GetService<IEventMediaFileService>(() => new EventMediaFileService(Uow, Uow.EventMediaFiles, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Event Reactions.
    /// </summary>
    public IEventReactionService EventReactions =>
        GetService<IEventReactionService>(() => new EventReactionService(Uow, Uow.EventReactions, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Events.
    /// </summary>
    public IEventService Events =>
        GetService<IEventService>(() => new EventService(Uow, Uow.Events, Mapper));

    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Media File Types.
    /// </summary>
    public IMediaFileTypeService MediaFileTypes =>
        GetService<IMediaFileTypeService>(() => new MediaFileTypeService(Uow, Uow.MediaFileTypes, Mapper));

    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Performers.
    /// </summary>
    public IPerformerService Performers =>
        GetService<IPerformerService>(() => new PerformerService(Uow, Uow.Performers, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Performer Types.
    /// </summary>
    public IPerformerTypeService PerformerTypes =>
        GetService<IPerformerTypeService>(() => new PerformerTypeService(Uow, Uow.PerformerTypes, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Poll Answers.
    /// </summary>
    public IPollAnswerService PollAnswers =>
        GetService<IPollAnswerService>(() => new PollAnswerService(Uow, Uow.PollAnswers, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Poll Options.
    /// </summary>
    public IPollOptionService PollOptions =>
        GetService<IPollOptionService>(() => new PollOptionService(Uow, Uow.PollOptions, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Reaction Types.
    /// </summary>
    public IReactionTypeService ReactionTypes =>
        GetService<IReactionTypeService>(() => new ReactionTypeService(Uow, Uow.ReactionTypes, Mapper));

    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Subscriptions.
    /// </summary>
    public ISubscriptionService Subscriptions =>
        GetService<ISubscriptionService>(() => new SubscriptionService(Uow, Uow.Subscriptions, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing User Event Ratings.
    /// </summary>
    public IUserEventRatingService UserEventRatings =>
        GetService<IUserEventRatingService>(() => new UserEventRatingService(Uow, Uow.UserEventRatings, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing User In Events.
    /// </summary>
    public IUserInEventService UserInEvents =>
        GetService<IUserInEventService>(() => new UserInEventService(Uow, Uow.UserInEvents, Mapper));


    // Identity Related Only
    
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Refresh Tokens.
    /// </summary>
    public IRefreshTokenService RefreshTokens =>
        GetService<IRefreshTokenService>(() => new RefreshTokenService(Uow, Uow.RefreshTokens, Mapper));
    
    
    /// <summary>
    /// Defines Connection to The Mapper Profile.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly IMapper Mapper;


    /// <summary>
    /// Service Constructor Defines Connection With Data Access Layer (Unit of Work). 
    /// </summary>
    /// <param name="uow">ata Access Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppBusinessLogic(IAppUnitOfWork uow, IMapper mapper) : base(uow) => Mapper = mapper;
}
