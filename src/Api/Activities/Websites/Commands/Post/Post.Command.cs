using Geekiam.Websites.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Websites.Commands.Post;

public class Command : IRequest<SingleResponse<Response>>
{
      [FromBody] public Website Website { get; set; }  
}



