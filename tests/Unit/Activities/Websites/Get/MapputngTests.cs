using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Activities.Feeds.Queries.Get;
using Geekiam.Data;
using Shouldly;
using Xunit;

namespace Geekiam.Activities.Websites.Get;

public class MappingTests
{
    private readonly IMapper _mapper;

    public MappingTests()
    {
        var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<Mapping>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
    }

    [Fact]
    public void Should_Map_Sources_To_Response()
    {
        var source = Builder<Sources>.CreateNew()
            .With(x => x.Protocol = "https")
            .With(x => x.Domain = "test.com")
            .With(x => x.FeedUrl = "/feed")
            .Build();

        var result = _mapper.Map<Response>(source);
        result.ShouldSatisfyAllConditions(
            () => result.Feed.ShouldBeEquivalentTo("https://test.com/feed"),
            () => result.Domain.ShouldBeEquivalentTo(source.Domain),
            () => result.Identifier.ShouldBeEquivalentTo(source.Identifier)
        );
    }
}