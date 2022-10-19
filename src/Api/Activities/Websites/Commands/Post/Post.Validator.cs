using System.Data;
using FluentValidation;
namespace  Threenine.Api.Activities.Websites.Websites.Commands.Post;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Feed.Name).NotEmpty();
        
        RuleFor(x => x.Feed.Domain).NotEmpty();
        RuleFor(x => x.Feed.Domain).Must(uri => Uri.TryCreate(uri, UriKind.Relative, out _)).When(x => !string.IsNullOrEmpty(x.Feed.Domain));

        RuleFor(x => x.Feed.Url).NotEmpty();
        RuleFor(x => x.Feed.Url).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.Feed.Url));
    }       
}
