using FluentValidation;
namespace Threenine.Api.Activities.Websites.Websites.Queries.GetbyId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }       
}
