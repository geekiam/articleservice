using FluentValidation;
using Geekiam.Data;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Patch;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();     
    }       
}
