using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Geekiam.Data;

public class Posts : BaseEntity, IValidatableObject
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Permalink { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
    public DateTime Published { get; set; }
    
    public virtual Sources Source { get; set; }
    
    public Guid SourceId { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Uri.IsWellFormedUriString(Permalink, UriKind.RelativeOrAbsolute))
        {
            yield return new  ValidationResult($"{nameof(Permalink)} is not a valid url");
        }
    }
}