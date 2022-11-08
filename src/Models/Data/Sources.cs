using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Common;
using Threenine.Models;

namespace Geekiam.Data;

public class Sources : BaseEntity, IValidatableObject
{
    public string Identifier { get; set; }
 
    public string Name { get; set; }
    public string Domain { get; set; }
    public string FeedUrl { get; set; }
    public string  Protocol { get; set; }
    
    public virtual ICollection<Posts> Posts { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Name == Domain)
        {
            yield return new ValidationResult("The name of the source cannot be the same as the domain name");
        }

        if (Domain == FeedUrl)
        {
            yield return new ValidationResult($"{nameof(Domain)} and {nameof(FeedUrl)} cannot be equal to each other");
        }
       
        if (!Regex.Match(Domain, RegularExpressions.DomainName, RegexOptions.IgnoreCase).Success)
        {
            yield return new ValidationResult($"{nameof(Domain)} is not valid");
        }
      
        if ( !Regex.Match(FeedUrl, RegularExpressions.RelativeUrlPath, RegexOptions.IgnoreCase).Success)
        {
            yield return new ValidationResult($"{nameof(FeedUrl)} is required to be relative path");
        }

    }
}