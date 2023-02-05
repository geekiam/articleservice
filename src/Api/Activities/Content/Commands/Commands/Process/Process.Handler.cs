using MediatR;
using Threenine.ApiResponse;
using WebScrapingService;

namespace Geekiam.Activities.Content.Commands.Commands.Process;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IPageContentService _service;

    public Handler(IPageContentService service)
    {
        _service = service;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var content = await _service.Get(request.Url);
        
        
        return new SingleResponse<Response>(new Response());
    }
}
