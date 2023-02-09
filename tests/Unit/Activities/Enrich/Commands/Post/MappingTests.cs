using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Data;
using Shouldly;
using WebScrapingService;
using Xunit;

namespace Geekiam.Activities.Enrich.Commands.Post;

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
    public void Should_Map_MetaInformation_to_Post()
    {
        var metaInformation = Builder<MetaInformation>.CreateNew().Build();

        var post = Builder<Posts>.CreateNew().Build();

        var result = _mapper.Map(metaInformation, post);
        result.ShouldSatisfyAllConditions(
            () => result.Image.ShouldBeEquivalentTo(metaInformation.Image),
            () => result.Summary.ShouldBeEquivalentTo(metaInformation.Summary)
        );
    }
}