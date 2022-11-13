using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Feeds.Commands.Update;

public class Command : IRequest<SingleResponse<Response>>
{
   [FromBody] public string SourceIdentifier { get; set; }
}


