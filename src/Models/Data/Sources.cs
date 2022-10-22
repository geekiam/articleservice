using System.ComponentModel.DataAnnotations;
using Threenine.Models;

namespace Geekiam.Data;

public class Sources : BaseEntity, IValidatableObject
{
    public string Identifier { get; set; }
 
    public string Name { get; set; }
    public string Domain { get; set; }
    public string FeedUrl { get; set; }
    
    public virtual ICollection<Posts> Posts { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Name == Domain)
        {
            yield return new ValidationResult("The name of the source cannot be the same as the domain name");
        }
    }
}