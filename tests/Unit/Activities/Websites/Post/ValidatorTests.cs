using System.Collections;
using Domain.Websites.Post;
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
    [ClassData(typeof(InValidDomainNames))]
    public void Should_Have_validation_error_for_domain_name(string input)
    {
        var query = new Command { Feed = new Feed() { Domain = input } };
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.Feed.Domain);
    }

    [Theory]
    [ClassData(typeof(ValidDomainNames))]
    public void Should_Not_Have_validation_error_for_domain_name(string input)
    {
        var query = new Command { Feed = new Feed() { Domain = input } };
        var result = _validator.TestValidate(query);
        result.ShouldNotHaveValidationErrorFor(x => x.Feed.Domain);
    }
}

public class ValidDomainNames : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "www.google.com" };
        yield return new object[] { "google.com" };
        yield return new object[] { "threenine.co.uk" };
        yield return new object[] { "www.threenine.co.uk" };
        yield return new object[] { "sub.threenine-info.com" };
        yield return new object[] { "garywoodfine.com" };
        yield return new object[] { "garywoodfine.ca" };
        yield return new object[] { "garywoodfine.eu" };
        yield return new object[] { "garywoodfine.com.au" };
        yield return new object[] { "bet365.com" };
    
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class InValidDomainNames : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "sub.-test.com" };
        yield return new object[] { "sub.test-.com" };
        yield return new object[] { "test.com/users" };
        yield return new object[] { "test.a" };
        yield return new object[] { "test.t.t.c" };
        yield return new object[] { "threenine,com" };
        yield return new object[] { ".com" };
        yield return new object[] { "test" };
        yield return new object[] { "test.123" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}