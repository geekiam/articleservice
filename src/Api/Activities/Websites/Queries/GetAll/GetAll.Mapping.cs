using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Get;

namespace Threenine.Api.Activities.Websites.Websites.Queries.GetAll;

public class Mapping: Profile
{
    public Mapping()
    {
       
       CreateMap<Sources, Feed>(MemberList.None)
           .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.FeedUrl))
           ;
    }
}
