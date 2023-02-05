using HtmlAgilityPack;

namespace WebScrapingService;

public class PageContentService : IPageContentService
{
   

    public async Task<MetaInformation> Get(string url)
    {
        var meta = new MetaInformation();
        var htmlDoc = await new HtmlWeb().LoadFromWebAsync(url);
        
        var metaTags = htmlDoc.DocumentNode.SelectNodes(MetaTags.TagNode);
        foreach (var tag in metaTags)
        {
            if ( tag.Attributes[MetaAttributes.Name] != null && tag.Attributes[MetaAttributes.Content] != null)
            {
                GetContent(tag,meta);
            }
            else if (tag.Attributes[MetaAttributes.Property] != null && tag.Attributes[MetaAttributes.Content] != null)
            {
                GetProperty(tag, meta);
            }
        }

        return meta;
    }

    private static void GetContent(HtmlNode tag,  MetaInformation meta)
    {
        switch ( tag.Attributes[MetaAttributes.Name].Value)
        {
            case MetaTags.Title:
                meta.Title =  tag.Attributes[MetaAttributes.Content].Value;
                break;
            case MetaTags.Description:
                meta.Description = tag.Attributes[MetaAttributes.Content].Value;
                break;
        }
    }

    private static void GetProperty(HtmlNode tag, MetaInformation meta)
    {
        switch (tag.Attributes[MetaAttributes.Property].Value)
        {
            case MetaTags.OpenGraphTitle:
                meta.Title = string.IsNullOrEmpty(meta.Title) ? tag.Attributes[MetaAttributes.Content].Value : meta.Title;
                break;
            case MetaTags.OpenGraphDescription:
                meta.Description = string.IsNullOrEmpty(meta.Description) ? tag.Attributes[MetaAttributes.Content].Value : meta.Description;
                break;
            case MetaTags.OpenGraphImage:
                meta.Image = string.IsNullOrEmpty(meta.Image) ? tag.Attributes[MetaAttributes.Content].Value : meta.Image;
                break;
            case MetaTags.OpenGraphSiteName:
                meta.SiteName =  string.IsNullOrEmpty(meta.SiteName) ? tag.Attributes[MetaAttributes.Content].Value : meta.SiteName;
                break;
        }
    }
}