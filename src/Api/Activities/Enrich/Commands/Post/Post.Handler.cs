using AutoMapper;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;
using WebScrapingService;

namespace Geekiam.Activities.Content.Commands.Post;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IMetaDataService _service;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Handler(IMetaDataService service, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _service = service;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.GetRepositoryAsync<Posts>().SingleOrDefaultAsync(x => x.Id.Equals(request.Id));
        var metaInformation = await _service.Get(post.Permalink);
        var content = _mapper.Map(metaInformation, post);
        
        _unitOfWork.GetRepository<Posts>().Update(content);
         await _unitOfWork.CommitAsync();


        return new SingleResponse<Response>(new Response{ Id = content.Id });
    }
}
