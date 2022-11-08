using System.Collections;
using System.Text.RegularExpressions;
using Common;
using Shouldly;
using Xunit;

namespace Geekiam;

public class RegularExpressionTests
{
    [Theory]
    [ClassData(typeof(RelativePathTestData))]
    public void Should_be_Relative_path(string path, bool expectedResult)
    {
        var result = Regex.IsMatch(path, RegularExpressions.RelativeUrlPath);
        result.ShouldBe(expectedResult);
    }
}

public class RelativePathTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "/test", true };
        yield return new object[] { "test/feed.xml", true };
        yield return new object[] { "/some-random-permalink", true };
        yield return new object[] { "/feed/", true };
        yield return new object[] { "garywoodfine.com", false };
        yield return new object[] { "https://threenine.co.uk", false };
        yield return new object[] { "ftp://threenine.co.uk", false };
        yield return new object[] { "/test-1234-test--3", true };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}