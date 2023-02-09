using AutoMapper;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace Geekiam.Activities.Feeds.Queries.Get;

public class Handler : IRequestHandler<Query, SingleResponse<Response>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public Handler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.GetRepositoryAsync<Sources>()
            .SingleOrDefaultAsync(x => x.Name.Equals(request.Name));


        return new SingleResponse<Response>(_mapper.Map<Response>(result));
    }
}