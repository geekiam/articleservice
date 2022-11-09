using Domain.Websites.Put;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;

namespace  Threenine.Api.Activities.Websites.Websites.Commands.Put;

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
