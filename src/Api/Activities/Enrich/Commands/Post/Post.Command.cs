using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Enrich.Commands.Post;

public class Command : IRequest<SingleResponse<Response>>
{
    [FromRoute(Name = "id")] public Guid Id { get; set; }
}