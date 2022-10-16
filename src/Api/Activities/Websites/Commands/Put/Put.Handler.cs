using Dtos.Websites.Put;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;

namespace  Threenine.Api.Activities.Websites.Websites.Commands.Put;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService _services;

    public Handler(IDataService services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Update<Sources, Feed, Response>(x =>
            x.Id == request.Id, request.Feed);
    }
}
