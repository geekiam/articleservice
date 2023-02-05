namespace WebScrapingService;

internal static class MetaTags
{
   // Node root to use for retrieving Meta Information
   internal const string TagNode = "//meta";
   
   // Standard tags
   internal const string Title = "title";
   internal const string Description = "description";
   
   //Open Graph Tags
   internal const string OpenGraphImage = "og:image";
   internal const string OpenGraphTitle = "og:title";
   internal const string OpenGraphDescription = "og:description";
   internal const string OpenGraphSiteName = "og:site_name";
   internal const string OpenGraphUrl = "og:url";
   
   // Twitter tags
   internal const string TwitterTitle = "twitter:title";
   internal const string TwitterDescription = "twitter:description";
   internal const string TwitterImage = "twitter:image";
   internal const string TwitterSite = "twitter:site";
   internal const string TwitterCreator = "twitter:creator";

}