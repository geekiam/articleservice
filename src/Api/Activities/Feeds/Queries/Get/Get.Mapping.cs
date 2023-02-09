using AutoMapper;
using Geekiam.Data;

namespace Geekiam.Activities.Feeds.Queries.Get;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Identifier))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.Feed, opt => opt.ConvertUsing(new FeedFormatter(), src => src));
    }
}

public class FeedFormatter : IValueConverter<Sources, string>
{
    public string Convert(Sources sourceMember, ResolutionContext context)
    {
        return $"{sourceMember.Protocol}://{sourceMember.Domain}{sourceMember.FeedUrl}";
    }
}