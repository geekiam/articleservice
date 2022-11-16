using AutoMapper;
using Geekiam.Data;
using Geekiam.Websites.Get;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace Geekiam.Activities.Websites.Queries.GetbyId;

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
        var result = await _unitOfWork.GetReadOnlyRepositoryAsync<Sources>()
            .SingleOrDefaultAsync(predicate: x => x.Id == request.Id);
        
        return new SingleResponse<Response>(new Response{ Website = _mapper.Map<Website>(result)});
    }
}
