
using Domain.Websites.Patch;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Patch;

public class Command : IRequest<SingleResponse<Response>>
{
        [FromRoute(Name = "id")] public Guid  Id { get; set; }
        [FromBody]  public JsonPatchDocument<Feed> Feed{ get; set; }
}

