using Domain.Websites.Post;
using MediatR;
using Threenine.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace Threenine.Api.Activities.Websites.Websites.Commands.Post;

public class Command : IRequest<SingleResponse<Response>>
{
      [FromBody] public Feed Feed { get; set; }  
}



