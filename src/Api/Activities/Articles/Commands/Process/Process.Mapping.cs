using System.ServiceModel.Syndication;
using AutoMapper;
using Geekiam.Data;

namespace Geekiam.Activities.Articles.Commands.Process;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<SyndicationItem, Posts>(MemberList.None)
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Links[0].Uri))
           ;
    }

   
}
internal class SummaryResolver : IValueResolver<SyndicationContent, Posts, string>
{
    public string Resolve(SyndicationContent source, Posts destination, string destMember, ResolutionContext context)
    {
        return "poo";
    }
}
