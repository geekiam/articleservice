using AutoMapper;
using Domain.Websites.Put;
using Geekiam.Data;

namespace  Threenine.Api.Activities.Websites.Websites.Commands.Put;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Feed, Sources>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.FeedUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol));

        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));
    }
}
