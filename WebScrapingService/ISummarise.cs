namespace WebScrapingService;

public interface ISummarise
{
    Task<string> Summary(string url);
}