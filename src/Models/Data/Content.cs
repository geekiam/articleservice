using Threenine.Models;

namespace Geekiam.Data;

public class Content : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
}