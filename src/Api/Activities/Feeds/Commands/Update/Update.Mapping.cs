using System.ServiceModel.Syndication;
using AutoMapper;
using Geekiam.Data;
using Geekiam.Websites.Update;

namespace Geekiam.Activities.Feeds.Commands.Update;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<SyndicationItem, Posts>(MemberList.None)
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Links[0].Uri));

        CreateMap<Article, Posts>(MemberList.None)
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Summary))
            .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Published))
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Summary, opt => opt.Ignore());

        CreateMap<Sources, FeedLink>(MemberList.None)
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.Feed, opt => opt.MapFrom(src => src.FeedUrl))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol));
    }

   
}

