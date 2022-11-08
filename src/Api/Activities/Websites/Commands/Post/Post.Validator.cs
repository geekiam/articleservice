using System.Data;
using System.Text.RegularExpressions;
using Api.Activities;
using Common;
using FluentValidation;
namespace  Threenine.Api.Activities.Websites.Websites.Commands.Post;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Feed.Name).NotEmpty();
        
        RuleFor(x => x.Feed.Domain).NotEmpty();
        RuleFor(x => x.Feed.Domain).Matches(RegularExpressions.DomainName, RegexOptions.IgnoreCase)
            .WithMessage("An absolute URL is required");

        RuleFor(x => x.Feed.Url).NotEmpty();
        RuleFor(x => x.Feed.Url).Matches(RegularExpressions.RelativeUrlPath, RegexOptions.IgnoreCase)
            .WithMessage("A relative url must be supplied");

        RuleFor(x => x.Feed.Protocol).NotEmpty();
    }       
}
