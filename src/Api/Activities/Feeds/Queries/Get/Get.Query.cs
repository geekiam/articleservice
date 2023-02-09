using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Feeds.Queries.Get;

public class Query : IRequest<SingleResponse<Response>>
{
    [FromQuery(Name = "name")] public string Name { get; set; }
}