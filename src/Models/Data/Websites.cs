using Threenine.Models;

namespace Geekiam.Data;

public class Websites : BaseEntity
{
    public string Identifier { get; set; }
    public string Name { get; set; }
    public string RootUrl { get; set; }
    public string FeedUrl { get; set; }
    
    public virtual ICollection<Articles> Articles { get; set; }

}