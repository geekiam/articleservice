using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Articles.Commands.Process;

public class Command : IRequest<SingleResponse<Response>>
{
   [FromBody] public string SourceIdentifier { get; set; }
}


