using AutoMapper;
using Dtos.Websites.Post;
using Geekiam.Data;

namespace  Threenine.Api.Activities.Websites.Websites.Commands.Post;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Feed, Sources>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.FeedUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom<IdentifierResolver>());
        

        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }

    /// <summary>
    /// Create a unique human readable identifier
    /// We do this by extracting the name portion of the url because this may be unique, however because
    /// we potentially could have a number of TLD we append a totally random integer value to it
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Local
    private class IdentifierResolver : IValueResolver<Feed, Sources, string>
    {
        public string Resolve(Feed source, Sources destination, string destMember, ResolutionContext context)
        {
            var domain = source.Domain.Split('.').ToArray();
            var id = domain[0] != "www" ? domain[0] : domain[2];
            return $"g_{id}_{new Random().Next(1, 9999)}";
        }
    }
}
