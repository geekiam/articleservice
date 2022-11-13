using Geekiam.Data;
using Geekiam.Feeds.Put;
using MediatR;
using Threenine;
using Threenine.ApiResponse;

namespace  Geekiam.Activities.Websites.Commands.Put;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService<Sources> _services;

    public Handler(IDataService<Sources> services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Update<Feed, Response>(x =>
            x.Id == request.Id, request.Feed);
    }
}
