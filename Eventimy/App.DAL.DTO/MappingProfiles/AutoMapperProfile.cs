using AutoMapper;
using App.DAL.DTO.Identity;

using DomainApp = App.Domain;


namespace App.DAL.DTO.MappingProfiles;


/// <summary>
/// Class Defines AutoMapper Configuration. Defines Data Access Layer Object Mappings To Entity And Reverse.
/// </summary>
public class AutoMapperProfile : Profile
{
    /// <summary>
    /// Basic AutoMapper Configuration Constructor. Configures All Mapping Profiles.
    /// </summary>
    public AutoMapperProfile()
    {
        /*
         * Defining Mapping For Each Data Access Layer Data Transfer Object.
         */
        
        CreateMap<Chat, DomainApp.Chat>().ReverseMap();
        
        CreateMap<ChatMediaFile, DomainApp.ChatMediaFile>().ReverseMap();
        
        CreateMap<ChatMessage, DomainApp.ChatMessage>().ReverseMap();
        
        CreateMap<ChatParticipant, DomainApp.ChatParticipant>().ReverseMap();
        
        CreateMap<ChatPoll, DomainApp.ChatPoll>().ReverseMap();
        
        CreateMap<City, DomainApp.City>().ReverseMap();

        CreateMap<Country, DomainApp.Country>().ReverseMap();
        
        CreateMap<Event, DomainApp.Event>().ReverseMap();
        
        CreateMap<EventCategory, DomainApp.EventCategory>().ReverseMap();

        CreateMap<EventMediaFile, DomainApp.EventMediaFile>().ReverseMap();
        
        CreateMap<EventReaction, DomainApp.EventReaction>().ReverseMap();

        CreateMap<MediaFileType, DomainApp.MediaFileType>().ReverseMap();

        CreateMap<Performer, DomainApp.Performer>().ReverseMap();
        
        CreateMap<PerformerType, DomainApp.PerformerType>().ReverseMap();
        
        CreateMap<PollAnswer, DomainApp.PollAnswer>().ReverseMap();
        
        CreateMap<PollOption, DomainApp.PollOption>().ReverseMap();
        
        CreateMap<ReactionType, DomainApp.ReactionType>().ReverseMap();

        CreateMap<Subscription, DomainApp.Subscription>().ReverseMap();
        
        CreateMap<UserEventRating, DomainApp.UserEventRating>().ReverseMap();
        
        CreateMap<UserInEvent, DomainApp.UserInEvent>().ReverseMap();


        // Identity Related Mappings
        
        
        CreateMap<RefreshToken, DomainApp.Identity.RefreshToken>().ReverseMap();
        
        CreateMap<AppUser, DomainApp.Identity.AppUser>().ReverseMap();
        
        CreateMap<AppRole, DomainApp.Identity.AppRole>().ReverseMap();
    }
}
