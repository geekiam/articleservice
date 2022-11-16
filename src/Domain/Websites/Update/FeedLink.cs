namespace Geekiam.Websites.Update;

public class FeedLink
{
    public Guid Id { get; set; }
    public string Domain { get; set; }
    public string Feed { get; set; }
    public string  Protocol { get; set; }

    public override string ToString()
    {
        return $"{Protocol}://{Domain}{Feed}";
    }
}