namespace Geekiam;

public static class StringUtilities
{
    /// <summary>
    /// Removes HTML tags from text supplied
    /// </summary>
    /// <param name="text">text that is required to be cleansed</param>
    /// <returns></returns>
    public static string RemoveHtmlTags(this string text)
    {
        return string.IsNullOrEmpty(text) ? string.Empty : System.Text.RegularExpressions.Regex.Replace(text, RegularExpressions.HTMLTagDetection, "").Trim();
    }
}