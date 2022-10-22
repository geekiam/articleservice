using System.Data;
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
        RuleFor(x => x.Domain).Must(uri => Uri.TryCreate(uri, UriKind.Relative, out _)).When(x => !string.IsNullOrEmpty(x.Domain));

        RuleFor(x => x.FeedUrl).NotEmpty();
        RuleFor(x => x.FeedUrl).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.FeedUrl));
    }
}