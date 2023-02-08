namespace WebScrapingService;

public interface IMediaService
{
   Task<string> Upload(string url);
}