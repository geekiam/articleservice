using FluentValidation;
using Geekiam.Data;

namespace Geekiam.Validators;

public class PostsValidators : AbstractValidator<Posts>
{
    public PostsValidators()
    {
        RuleFor(x => x.Summary).NotNull().NotEmpty();
    }
}