using AutoMapper;
using Dtos.Websites.Put;
using Geekiam.Data;

namespace  Threenine.Api.Activities.Websites.Websites.Commands.Put;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Feed, Sources>(MemberList.None)
            // TODO: Implement Mapping here
          ;

        CreateMap<Sources, Response>(MemberList.None)
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));
    }
}
