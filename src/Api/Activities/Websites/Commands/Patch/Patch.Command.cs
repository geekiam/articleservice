using Geekiam.Websites.Patch;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Websites.Commands.Patch;

public class Command : IRequest<SingleResponse<Response>>
{
        [FromRoute(Name = "id")] public Guid  Id { get; set; }
        [FromBody]  public JsonPatchDocument<Website> Feed{ get; set; }
}

