using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Put;

namespace  Geekiam.Activities.Websites.Commands.Put;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Feed, Sources>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.FeedUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol));

        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));
    }
}
