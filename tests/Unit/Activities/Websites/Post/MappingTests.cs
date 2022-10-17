using Dtos.Websites.Post;
using Geekiam.Data;
using Threenine.Api.Activities.Websites.Websites.Commands.Post;

namespace Geekiam.Activities.Websites.Post;
using AutoMapper;
using FizzWare.NBuilder;
using Shouldly;
using Xunit;



public class MappingTests
{
    private readonly IMapper _mapper;

    public MappingTests()
    {
        var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<Mapping>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
    }

    private static Feed TestFeed => Builder<Feed>.CreateNew()
        .Build();

    private static Command TestInput => Builder<Command>.CreateNew().Build();

    [Fact]
    public void Should_Map_Feed_to_Sources()
    {
        var sources = _mapper.Map<Sources>(TestFeed);

        sources.ShouldSatisfyAllConditions(
            () => sources.ShouldBeOfType<Sources>(),
            () => sources.Name.ShouldBeEquivalentTo(TestFeed.Name),
            () => sources.RootUrl.ShouldBeEquivalentTo(TestFeed.RootUrl),
            () => sources.FeedUrl.ShouldBeEquivalentTo(TestFeed.Url)
        );
    }

    /*[Fact]
    public void Should_Map_Actor_to_Response()
    {
        var response = _mapper.Map<Response>(TestActor);

        response.ShouldSatisfyAllConditions(
            () => response.ShouldBeOfType<Response>(),
            () => response.Id.ShouldBeEquivalentTo(TestActor.Id)
        );
    }*/
}