using AutoMapper;
using App.BLL.DTO.Identity;

using DalAppDTO = App.DAL.DTO;

namespace App.BLL.DTO.MappingProfiles;


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
        
        CreateMap<Chat, DalAppDTO.Chat>().ReverseMap();
        
        CreateMap<ChatMediaFile, DalAppDTO.ChatMediaFile>().ReverseMap();
        
        CreateMap<ChatMessage, DalAppDTO.ChatMessage>().ReverseMap();
        
        CreateMap<ChatParticipant, DalAppDTO.ChatParticipant>().ReverseMap();
        
        CreateMap<ChatPoll, DalAppDTO.ChatPoll>().ReverseMap();
        
        CreateMap<City, DalAppDTO.City>().ReverseMap();

        CreateMap<Country, DalAppDTO.Country>().ReverseMap();
        
        CreateMap<Event, DalAppDTO.Event>().ReverseMap();
        
        CreateMap<EventCategory, DalAppDTO.EventCategory>().ReverseMap();

        CreateMap<EventMediaFile, DalAppDTO.EventMediaFile>().ReverseMap();
        
        CreateMap<EventReaction, DalAppDTO.EventReaction>().ReverseMap();

        CreateMap<MediaFileType, DalAppDTO.MediaFileType>().ReverseMap();

        CreateMap<Performer, DalAppDTO.Performer>().ReverseMap();
        
        CreateMap<PerformerType, DalAppDTO.PerformerType>().ReverseMap();
        
        CreateMap<PollAnswer, DalAppDTO.PollAnswer>().ReverseMap();
        
        CreateMap<PollOption, DalAppDTO.PollOption>().ReverseMap();
        
        CreateMap<ReactionType, DalAppDTO.ReactionType>().ReverseMap();

        CreateMap<Subscription, DalAppDTO.Subscription>().ReverseMap();
        
        CreateMap<UserEventRating, DalAppDTO.UserEventRating>().ReverseMap();
        
        CreateMap<UserInEvent, DalAppDTO.UserInEvent>().ReverseMap();


        // Identity Related Mappings
        
        
        CreateMap<RefreshToken, DalAppDTO.Identity.RefreshToken>().ReverseMap();
        
        CreateMap<AppUser, DalAppDTO.Identity.AppUser>().ReverseMap();
        
        CreateMap<AppRole, DalAppDTO.Identity.AppRole>().ReverseMap();
    }
}
