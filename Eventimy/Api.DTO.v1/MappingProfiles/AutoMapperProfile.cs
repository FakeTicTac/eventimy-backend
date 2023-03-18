using AutoMapper;
using Api.DTO.v1.Identity;

using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.MappingProfiles;


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
        
        CreateMap<Chat, BllAppDTO.Chat>().ReverseMap();
        
        CreateMap<ChatMediaFile, BllAppDTO.ChatMediaFile>().ReverseMap();
        
        CreateMap<ChatMessage, BllAppDTO.ChatMessage>().ReverseMap();
        
        CreateMap<ChatParticipant, BllAppDTO.ChatParticipant>().ReverseMap();
        
        CreateMap<ChatPoll, BllAppDTO.ChatPoll>().ReverseMap();
        
        CreateMap<City, BllAppDTO.City>().ReverseMap();

        CreateMap<Country, BllAppDTO.Country>().ReverseMap();
        
        CreateMap<Event, BllAppDTO.Event>().ReverseMap();
        
        CreateMap<EventCategory, BllAppDTO.EventCategory>().ReverseMap();

        CreateMap<EventMediaFile, BllAppDTO.EventMediaFile>().ReverseMap();
        
        CreateMap<EventReaction, BllAppDTO.EventReaction>().ReverseMap();

        CreateMap<MediaFileType, BllAppDTO.MediaFileType>().ReverseMap();

        CreateMap<Performer, BllAppDTO.Performer>().ReverseMap();
        
        CreateMap<PerformerType, BllAppDTO.PerformerType>().ReverseMap();
        
        CreateMap<PollAnswer, BllAppDTO.PollAnswer>().ReverseMap();
        
        CreateMap<PollOption, BllAppDTO.PollOption>().ReverseMap();
        
        CreateMap<ReactionType, BllAppDTO.ReactionType>().ReverseMap();

        CreateMap<Subscription, BllAppDTO.Subscription>().ReverseMap();
        
        CreateMap<UserEventRating, BllAppDTO.UserEventRating>().ReverseMap();
        
        CreateMap<UserInEvent, BllAppDTO.UserInEvent>().ReverseMap();


        // Identity Related Mappings
        
        
        CreateMap<RefreshToken, BllAppDTO.Identity.RefreshToken>().ReverseMap();
        
        CreateMap<AppUser, BllAppDTO.Identity.AppUser>().ReverseMap();
        
        CreateMap<AppRole, BllAppDTO.Identity.AppRole>().ReverseMap();
    }
}
