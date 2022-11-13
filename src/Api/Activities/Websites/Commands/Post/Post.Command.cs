using Geekiam.Feeds.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Websites.Commands.Post;

public class Command : IRequest<SingleResponse<Response>>
{
      [FromBody] public Feed Feed { get; set; }  
}



