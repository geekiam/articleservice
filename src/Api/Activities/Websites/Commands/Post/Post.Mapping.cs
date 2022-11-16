using AutoMapper;
using Geekiam.Data;
using Geekiam.Websites.Post;

namespace  Geekiam.Activities.Websites.Commands.Post;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Website, Sources>(MemberList.None)
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Domain, opt => opt.MapFrom(src => src.Domain))
            .ForMember(dest => dest.FeedUrl, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom<IdentifierResolver>())
            .ForMember(dest => dest.Media, opt => opt.MapFrom<MediaResolver>());
        

        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }

    /// <summary>
    /// Create a unique human readable identifier
    /// We do this by extracting the name portion of the url because this may be unique, however because
    /// we potentially could have a number of TLD we append a totally random integer value to it
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Local
    private class IdentifierResolver : IValueResolver<Website, Sources, string>
    {
        public string Resolve(Website source, Sources destination, string destMember, ResolutionContext context)
        {
            var domain = source.Domain.Split('.').ToArray();
            var id = domain[0] != "www" ? domain[0] : domain[2];
            return $"g_{id}_{new Random().Next(1, 9999)}";
        }
    }
    
    private class MediaResolver : IValueResolver<Website, Sources, string>
    {
        public string Resolve(Website source, Sources destination, string destMember, ResolutionContext context)
        {
            return source.Media.ToLower() switch
            {
                "text" => Media.Text.ToString(),
                "video" => Media.Video.ToString(),
                "audio" => Media.Audio.ToString(),
                _ => Media.Text.ToString()
            };
        }
    }
}
