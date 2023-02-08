using FluentValidation;

namespace Geekiam.Activities.Content.Commands.Post;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }       
}
