namespace Geekiam.Feeds.Update;

public class Feed
{
    public string Url { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public Guid SourceId { get; set; }
    public DateTime Published { get; set; }
    
    
}