using System.ServiceModel.Syndication;
using System.Xml;
using AutoMapper;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace Api.Process;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Handler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var feeds = await _unitOfWork.GetRepositoryAsync<Sources>().GetListAsync(x => x.Active == true);
        
        feeds.Items.ToList().ForEach(x =>
        {
            var url = new Uri($"{x.Protocol}://{x.Domain}{x.FeedUrl}");
       
            using var reader = XmlReader.Create(url.ToString());
            var feed =  SyndicationFeed.Load(reader);
        
            feed.Items.ToList().ForEach(y =>
            {
                var posts = new Posts
                {
                    Permalink = y.Links[0].Uri.ToString(),
                    Title = y.Title.Text,
                    Summary = y.Summary.Text,
                    SourceId = Guid.Parse("6034aaa2-8549-4885-a5b4-648c3db2ae4b"),
                    Published = y.PublishDate.UtcDateTime
                
                };
                _unitOfWork.GetRepositoryAsync<Posts>().InsertAsync(posts, cancellationToken);
                _unitOfWork.CommitAsync();
            });
        });
        
      
       
       
            
        return new SingleResponse<Response>(new Response());
    }
}
