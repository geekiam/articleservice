namespace WebScrapingService;

public interface IMetaDataService
{
   Task<MetaInformation> Get(string url);
}