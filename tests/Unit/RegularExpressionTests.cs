using System.Text.RegularExpressions;
using Common;
using Shouldly;
using Xunit;

namespace Geekiam;

public class RegularExpressionTests
{
    [Theory]
    [InlineData("/poo")]
    [InlineData("test/feed.xml")]
    [InlineData("/some-random-permalink")]
    [InlineData("/feed/")]
    public void Should_be_Relative_path(string path)
    {
        var result = Regex.IsMatch(path, RegularExpressions.RelativeUrlPath);
        result.ShouldBeTrue();
    }
    
    [Theory]
    [InlineData("garywoodfine.com")]
    [InlineData("https://threenine.co.uk")]
    [InlineData("ftp://threenine.co.uk")]
    public void Should_not_be_Relative_path(string path)
    {
        var result = Regex.IsMatch(path, RegularExpressions.RelativeUrlPath);
        result.ShouldBeFalse();
    }
    
}