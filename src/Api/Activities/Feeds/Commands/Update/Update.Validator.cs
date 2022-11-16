using FluentValidation;

namespace Geekiam.Activities.Feeds.Commands.Update;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.SourceIdentifier).NotEmpty();
    }       
}
