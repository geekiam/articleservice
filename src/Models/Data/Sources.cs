using Threenine.Models;

namespace Geekiam.Data;

public class Sources : BaseEntity
{
 
    public string Name { get; set; }
    public string RootUrl { get; set; }
    public string FeedUrl { get; set; }
    
    public virtual ICollection<Posts> Posts { get; set; }

}