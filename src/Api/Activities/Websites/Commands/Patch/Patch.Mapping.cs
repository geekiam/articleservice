using AutoMapper;
using Domain.Websites.Patch;
using Geekiam.Data;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Patch;

public class Mapping: Profile
{
    public Mapping()
    {
        
        
        CreateMap<Sources, Response>(MemberList.None);
 
        CreateMap<Sources, Feed>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.FeedUrl))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol));
            

        CreateMap<Feed, Sources>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.FeedUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol));

    }
}
