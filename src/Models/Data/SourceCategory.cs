
using Threenine.Models;

namespace Geekiam.Data;

public class SourceCategory : BaseEntity
{
    public Guid SourceId { get; set; }
    public Sources Source { get; set; }

    public Guid CategoryId { get; set; }
    public Categories Category { get; set; }
    
}