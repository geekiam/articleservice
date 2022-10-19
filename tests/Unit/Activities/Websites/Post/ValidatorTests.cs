using Dtos.Websites.Post;
using FluentValidation.TestHelper;
using Threenine.Api.Activities.Websites.Websites.Commands.Post;
using Xunit;

namespace Geekiam.Activities.Websites.Post;

public class ValidatorTests
{
    private readonly Validator _validator;

    public ValidatorTests()
    {
        _validator = new Validator();
    }

    [Theory]
    [InlineData("https://garywoodfine.com")]
    [InlineData("https://www.garywoodfine.com")]
    [InlineData("http://www.garywoodfine.com")]
   
    public void Should_Have_validation_error_for_abolute_url_being_passed(string input)
    {
        var query = new Command { Feed = new Feed(){ Domain = input} };
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.Feed.Domain);
    }
    
    [Theory]
    [InlineData("garywoodfine.com")]
    [InlineData("google.com")]
    [InlineData("geekiam.io")]
    [InlineData("www.geekiam.com")]
    public void Should_Have_validation_error_for_empty_id(string input)
    {
        var query = new Command { Feed = new Feed(){ Domain = input} };
        var result = _validator.TestValidate(query);
        result.ShouldNotHaveValidationErrorFor(x => x.Feed.Domain);
    }

    
    
}