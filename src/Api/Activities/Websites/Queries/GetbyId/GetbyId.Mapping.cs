using AutoMapper;
using Geekiam.Data;
using Geekiam.Websites.Get;

namespace Geekiam.Activities.Websites.Queries.GetbyId;

public class Mapping: Profile
{
    public Mapping()
    {
       
        CreateMap<Sources, Website>(MemberList.None)
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.FeedUrl));
    }
}
