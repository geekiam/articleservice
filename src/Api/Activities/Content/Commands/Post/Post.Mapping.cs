using AutoMapper;
using WebScrapingService;

namespace Geekiam.Activities.Content.Commands.Post;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<MetaInformation, Data.Content>()
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.Trim()));



    }
}
