using System.Text.RegularExpressions;
using FluentValidation;

namespace  Geekiam.Activities.Websites.Commands.Put;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        
        RuleFor(x => x.Website.Name).NotEmpty();
        
        RuleFor(x => x.Website.Domain).NotEmpty();
        RuleFor(x => x.Website.Domain).Matches(RegularExpressions.DomainName, RegexOptions.IgnoreCase)
            .WithMessage("An absolute URL is required");

        RuleFor(x => x.Website.Url).NotEmpty();
        RuleFor(x => x.Website.Url).Matches(RegularExpressions.RelativeUrlPath, RegexOptions.IgnoreCase)
            .WithMessage("A relative url must be supplied");

        RuleFor(x => x.Website.Protocol).NotEmpty();
    }       
}
