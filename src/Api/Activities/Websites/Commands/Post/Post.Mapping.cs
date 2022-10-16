using AutoMapper;

using Dtos.Websites.Post;
using Geekiam.Data;

namespace  Threenine.Api.Activities.Websites.Websites.Commands.Post;

public class Mapping: Profile
{
    public Mapping()
    {
        
        
        CreateMap<Feed, Sources>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.RootUrl, opt => opt.MapFrom(src => src.RootUrl))
            .ForMember(dest => dest.FeedUrl, opt => opt.MapFrom(src => src.Url));
        

        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}
