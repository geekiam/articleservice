using Dtos.Websites.Post;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Post;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService _services;

    public Handler(IDataService services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
       
        return await _services.Create<Sources, Feed, Response>(request.Feed);
    }
}
