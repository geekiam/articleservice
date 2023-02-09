using FluentValidation;

namespace Geekiam.Activities.Enrich.Commands.Post;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}