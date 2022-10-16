using AutoMapper;
using Dtos.Websites.Patch;
using Geekiam.Data;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Patch;

public class Mapping: Profile
{
    public Mapping()
    {
        // TODO : Complete Mapping
        
        CreateMap<Sources, Response>(MemberList.None);
 
        CreateMap<Sources, Feed>(MemberList.None);

        CreateMap<Feed, Sources>(MemberList.None);

    }
}
