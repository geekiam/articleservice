using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Activities.Websites.Commands.Post;
using Geekiam.Data;
using Geekiam.Feeds.Post;
using Shouldly;
using Xunit;

namespace Geekiam.Activities.Websites.Post;

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
            () => sources.Domain.ShouldBeEquivalentTo(TestFeed.Domain),
            () => sources.FeedUrl.ShouldBeEquivalentTo(TestFeed.Url),
            () => sources.Identifier.ShouldNotBeNull()
        );
    }
}