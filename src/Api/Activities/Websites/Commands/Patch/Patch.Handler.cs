using Dtos;
using MediatR;
using Threenine;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

using Dtos.Websites.Patch;
using Geekiam.Data;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Patch;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService _services;

    public Handler(IDataService services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Patch<Sources, Feed, Response>(x => x.Id == request.Id,
            request.Feed);
    }
}
