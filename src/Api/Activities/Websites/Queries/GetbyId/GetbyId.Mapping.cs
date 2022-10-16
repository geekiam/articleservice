using AutoMapper;
using Geekiam.Data;

namespace Threenine.Api.Activities.Websites.Websites.Queries.GetbyId;

public class Mapping: Profile
{
    public Mapping()
    {
        // TODO: Add Mapping
        CreateMap<Sources, Response>(MemberList.None);
    }
}
