using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Activities.Websites.Commands.Post;
using Geekiam.Data;
using Geekiam.Websites.Post;
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

    private static Website TestWebsite => Builder<Website>.CreateNew()
        .Build();

    private static Command TestInput => Builder<Command>.CreateNew().Build();

    [Fact]
    public void Should_Map_Feed_to_Sources()
    {
        var sources = _mapper.Map<Sources>(TestWebsite);

        sources.ShouldSatisfyAllConditions(
            () => sources.ShouldBeOfType<Sources>(),
            () => sources.Name.ShouldBeEquivalentTo(TestWebsite.Name),
            () => sources.Domain.ShouldBeEquivalentTo(TestWebsite.Domain),
            () => sources.FeedUrl.ShouldBeEquivalentTo(TestWebsite.Url),
            () => sources.Identifier.ShouldNotBeNull()
        );
    }
}