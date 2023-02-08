using HtmlAgilityPack;
namespace WebScrapingService;

public class MetaDataService : IMetaDataService
{
    private readonly IMediaService _mediaService;
    private readonly ISummarise _summarise;

    public MetaDataService(IMediaService mediaService, ISummarise summarise)
    {
        _mediaService = mediaService;
        _summarise = summarise;
    }

    public async Task<MetaInformation> Get(string url)
    {
        var meta = new MetaInformation();
        var htmlDoc = await new HtmlWeb().LoadFromWebAsync(url);
        
        var metaTags = htmlDoc.DocumentNode.SelectNodes(MetaTags.TagNode);
        foreach (var tag in metaTags)
        {
            if (tag.Attributes[MetaAttributes.Property] != null && tag.Attributes[MetaAttributes.Content] != null)
            {
                GetProperty(tag, meta);
            }
        }
        meta.Summary = await _summarise.Summary(url);
        return meta;
    }
    

    private void GetProperty(HtmlNode tag, MetaInformation meta)
    {
        switch (tag.Attributes[MetaAttributes.Property].Value)
        {
            case MetaTags.OpenGraphImage:
                var imageUrl = string.IsNullOrEmpty(meta.Image)
                    ? tag.Attributes[MetaAttributes.Content].Value
                    : meta.Image;
                meta.Image =  _mediaService.Upload(imageUrl).Result;
                break;
            case MetaTags.OpenGraphSiteName:
                meta.SiteName =  string.IsNullOrEmpty(meta.SiteName) ? tag.Attributes[MetaAttributes.Content].Value : meta.SiteName;
                break;
        }
    }
}