using Geekiam.Data;
using Geekiam.Feeds.Post;
using MediatR;
using Threenine;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Websites.Commands.Post;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService<Sources> _services;

    public Handler(IDataService<Sources> services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
       
        return await _services.Create<Feed, Response>(request.Feed);
    }
}
