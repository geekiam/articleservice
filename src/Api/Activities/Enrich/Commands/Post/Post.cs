using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Content.Commands.Post;

[Route(Routes.Enrich)]
public class Post : EndpointBaseAsync.WithRequest<Command>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public Post(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{id:guid}")]
    [SwaggerOperation(
        Summary = "Create a new content entry from the post",
        Description = "Create a new content entry from the post",
        OperationId = "6d405a3b-a743-4e21-b537-467d123a179d",
        Tags = new[] { Routes.Enrich })
    ]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromRoute] Command request, CancellationToken cancellationToken = new())
    {
        var result = await _mediator.Send(request, cancellationToken);
        
        if (result.IsValid)
            return new CreatedResult(new Uri(Routes.Enrich, UriKind.Relative), new { result.Item.Id });

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
