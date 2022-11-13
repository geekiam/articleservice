using System.ServiceModel.Syndication;
using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Update;

namespace Geekiam.Activities.Feeds.Commands.Update;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<SyndicationItem, Posts>(MemberList.None)
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Links[0].Uri));

        CreateMap<Feed, Posts>(MemberList.None)
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
            .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Published))
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Url));
        

    }

   
}

