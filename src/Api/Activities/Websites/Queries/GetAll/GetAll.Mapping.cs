using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Get;

namespace Threenine.Api.Activities.Websites.Websites.Queries.GetAll;

public class Mapping: Profile
{
    public Mapping()
    {
       // TODO:  Complete Mapping
       CreateMap<Sources, Feed>(MemberList.None)
           
           ;
    }
}
