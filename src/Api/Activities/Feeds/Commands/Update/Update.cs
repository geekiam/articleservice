using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Feeds.Commands.Update;

[Route(Routes.Feeds)]
public class Process : EndpointBaseAsync.WithRequest<Command>.WithoutResult
{
    private readonly IMediator _mediator;

    public Process(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost(":update/{identifier}")]
    [SwaggerOperation(
        Summary = "Processes",
        Description = "Processes",
        OperationId = "d9025b3d-0755-4731-898e-7994dda445d7",
        Tags = new[] { Routes.Feeds })
    ]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override async Task<ActionResult> HandleAsync([FromRoute] Command request, CancellationToken cancellationToken = new())
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
