using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Geekiam.Data;

public class Categories : BaseEntity, IValidatableObject
{
    public string Name { get; set; }
    public string Permalink { get; set; }
    
    public virtual ICollection<SourceCategory> SourceCategories { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Uri.IsWellFormedUriString(Permalink, UriKind.Relative))
        {
            yield return new  ValidationResult($"{nameof(Permalink)} is not a valid url");
        }
    }
}