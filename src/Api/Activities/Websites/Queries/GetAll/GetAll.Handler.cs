using AutoMapper;
using Geekiam.Data;
using Geekiam.Websites.Get;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace  Geekiam.Activities.Websites.Queries.GetAll;

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
        
        return new SingleResponse<Response>(new Response { Sites = _mapper.Map<List<Website>>(results.Items)});
    }
}
