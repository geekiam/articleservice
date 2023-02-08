using Threenine.Models;

namespace Geekiam.Data;

public class Content : BaseEntity
{
    public Guid PostId { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
    
    
    public virtual Posts Post { get; set; }
}