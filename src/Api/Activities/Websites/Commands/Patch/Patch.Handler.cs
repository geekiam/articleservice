using Geekiam.Data;
using Geekiam.Websites.Patch;
using MediatR;
using Threenine;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Websites.Commands.Patch;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService<Sources> _services;

    public Handler(IDataService<Sources> services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Patch<Website, Response>(x => x.Id == request.Id,
            request.Feed);
        
    }
}
