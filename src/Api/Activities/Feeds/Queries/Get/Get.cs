using Api.Activities;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Feeds.Queries.Get;

[Route(Routes.Feeds)]
public class Get : EndpointBaseAsync.WithRequest<Query>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public Get(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get",
        Description = "Get",
        OperationId = "5020f220-e6b0-4d5d-b767-61a995e695df",
        Tags = new[] { Routes.Feeds })
    ]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromQuery] Query request,
        CancellationToken cancellationToken = new())
    {
        var result = await _mediator.Send(request, cancellationToken);

        if (result.IsValid)
            return new OkObjectResult(result.Item);

        return await HandleErrors(result.Errors);
    }

    private Task<ActionResult> HandleErrors(List<KeyValuePair<string, string[]>> errors)
    {
        ActionResult result = null;
        errors.ForEach(error =>
        {
            result = error.Key switch
            {
                ErrorKeyNames.Conflict => new ConflictResult(),
                _ => new BadRequestObjectResult(errors)
            };
        });
        return Task.FromResult(result);
    }
}