using AutoMapper;
using Geekiam.Data;
using WebScrapingService;

namespace Geekiam.Activities.Enrich.Commands.Post;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<MetaInformation, Posts>(MemberList.None)
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.Trim()))
            ;
    }
}