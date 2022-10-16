using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;
namespace Threenine.Api.Activities.Websites.Websites.Queries.GetAll;

public class Query : IRequest<SingleResponse<Response>>
{
   [FromRoute]  public Guid Id { get; set; }   
}


