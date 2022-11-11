using Common;
using Shouldly;
using Xunit;

namespace Geekiam.Utilities;

public class StringUtilitiesTest
{
    [Theory]
    [InlineData("<p>test</p>", "test")]
    [InlineData("<p style=\"float:right; margin:0 0 10px 15px; width:240px;\"><img src=\"https://images.cointelegraph.com/images/840_aHR0cHM6Ly9zMy5jb2ludGVsZWdyYXBoLmNvbS91cGxvYWRzLzIwMjItMTEvOTY3ODRhNTYtZGFkMC00YTM1LTkzYzUtMGRjZjI5YTFlMzFmLmpwZw==.jpg\"></p><p>test</p>", "test")]
    public void ShouldRemoveHtmlFromText(string text, string expected )
    {
        var result = text.RemoveHtmlTags();
        result.ShouldBeEquivalentTo(expected);
    }
    
}