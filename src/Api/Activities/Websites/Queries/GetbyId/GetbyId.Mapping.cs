using AutoMapper;
using Geekiam.Data;

namespace Geekiam.Activities.Websites.Queries.GetbyId;

public class Mapping: Profile
{
    public Mapping()
    {
        // TODO: Add Mapping
        CreateMap<Sources, Response>(MemberList.None);
    }
}
