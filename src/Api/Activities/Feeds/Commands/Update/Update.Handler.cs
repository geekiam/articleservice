using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Update;
using MediatR;
using Services;
using Strategies;
using Threenine.ApiResponse;
using Threenine.Data;

namespace Geekiam.Activities.Feeds.Commands.Update;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStrategy<FeedLink, List<Article>> _strategy;
    private readonly IProcessService<Article, Sources> _processService;


    public Handler(IUnitOfWork unitOfWork, IMapper mapper, IStrategy<FeedLink, List<Article>> strategy, IProcessService<Article, Sources> processService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _strategy = strategy;
        _processService = processService;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var website = await _unitOfWork.GetRepositoryAsync<Sources>()
            .SingleOrDefaultAsync(f => f.Identifier == request.SourceIdentifier);
       
        var feeds = await _strategy.Execute(_mapper.Map<FeedLink>(website), cancellationToken);

        var recentlyAdded = feeds.Where(x => x.Published >= website.LastUpdate).ToList();

        if (recentlyAdded.Count > 0)
        {
           await _processService.Process(recentlyAdded, website);
        }
        
        return new SingleResponse<Response>(new Response { NumberOfPosts = recentlyAdded.Count });
    }
}