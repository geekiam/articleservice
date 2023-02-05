using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Content.Commands.Commands.Process;

public class Command : IRequest<SingleResponse<Response>>
{
        [FromBody] public string Url { get; set; }
}


