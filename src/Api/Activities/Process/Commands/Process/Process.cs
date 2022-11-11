using Api.Activities;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace Api.Process;

[Route(Routes.Process)]
public class Process : EndpointBaseAsync.WithRequest<Command>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public Process(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost(":process")]
    [SwaggerOperation(
        Summary = "Process",
        Description = "Process",
        OperationId = "d9025b3d-0755-4731-898e-7994dda445d7",
        Tags = new[] { Routes.Process })
    ]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromBody] Command request, CancellationToken cancellationToken = new())
    {
        var result = await _mediator.Send(request, cancellationToken);
        
        if (result.IsValid)
            return new CreatedResult(new Uri(Routes.Process, UriKind.Relative), new { result.Item.Id });

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
