using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace Geekiam.Activities.Websites.Queries.GetAll;

public class Query : IRequest<SingleResponse<Response>>
{
   [FromRoute]  public Guid Id { get; set; }   
}


