using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Threenine.Models;

namespace Geekiam.Data;

public class Articles : BaseEntity
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Permalink { get; set; }
    public DateTime Published { get; set; }
    
    public virtual Websites Website { get; set; }
    public Guid WebsiteId { get; set; }
    
    
}