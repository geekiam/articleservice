using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Threenine.Models;

namespace Geekiam.Data;

public class Posts : BaseEntity
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Permalink { get; set; }
    public DateTime Published { get; set; }
    
    public virtual Sources Source { get; set; }
    public Guid SourceId { get; set; }
    
    
}