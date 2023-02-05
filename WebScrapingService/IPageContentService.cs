namespace WebScrapingService;

public interface IPageContentService
{
   Task<MetaInformation> Get(string url);
}