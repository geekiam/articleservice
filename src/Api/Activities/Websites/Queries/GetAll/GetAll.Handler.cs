using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Get;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace  Threenine.Api.Activities.Websites.Websites.Queries.GetAll;

public class Handler : IRequestHandler<Query, SingleResponse<Response>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Handler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var results = await _unitOfWork.GetReadOnlyRepositoryAsync<Sources>()
            .GetListAsync( size: Int32.MaxValue);
        
        return new SingleResponse<Response>(new Response { Feed = _mapper.Map<List<Feed>>(results.Items)});
    }
}
