using AutoMapper;
using Domain.Websites.Get;
using Geekiam.Data;


namespace Threenine.Api.Activities.Websites.Websites.Queries.GetAll;

public class Mapping: Profile
{
    public Mapping()
    {
       
       CreateMap<Sources, Feed>(MemberList.None)
           .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.FeedUrl))
           .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Identifier))
           ;
    }
}
