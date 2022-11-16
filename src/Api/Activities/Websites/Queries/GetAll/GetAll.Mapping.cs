using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Get;

namespace Geekiam.Activities.Websites.Queries.GetAll;

public class Mapping: Profile
{
    public Mapping()
    {
       
       CreateMap<Sources, Feed>(MemberList.None)
           .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.FeedUrl))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Identifier))
           ;
    }
}
