using System.Text.RegularExpressions;
using Common;
using FluentValidation;
using Geekiam.Data;

namespace Geekiam.Validators;

public class SourcesValidators : AbstractValidator<Sources>
{
    public SourcesValidators()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Name).MaximumLength(255);
        RuleFor(x => x).Must(x => x.Name != x.Domain).WithMessage("The name of the source cannot be the same as the domain name").WithName("Name");
        
        RuleFor(x => x.Domain).NotEmpty();
        RuleFor(x => x.Domain).Matches(RegularExpressions.DomainName, RegexOptions.IgnoreCase)
            .WithMessage("Not a valid domain name");

        RuleFor(x => x.FeedUrl).NotEmpty();
        RuleFor(x => x.FeedUrl).Matches(RegularExpressions.RelativeUrlPath, RegexOptions.IgnoreCase)
            .WithMessage("A relative url must be supplied");
    }
}