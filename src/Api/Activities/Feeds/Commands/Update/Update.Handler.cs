using System.ServiceModel.Syndication;
using System.Xml;
using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Update;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace Geekiam.Activities.Feeds.Commands.Update;

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
        var website = await _unitOfWork.GetRepositoryAsync<Sources>()
            .SingleOrDefaultAsync(f => f.Identifier == request.SourceIdentifier);
        
        var feeds = GetFeed(website);
      
        feeds.ForEach(feed =>
        {
            var post = _mapper.Map<Posts>(feed);
            post.SourceId = website.Id;
            _unitOfWork.GetRepository<Posts>()
                .InsertNotExists(post => post.SourceId.Equals(feed.SourceId) && post.Permalink.Equals(feed.Url),
                    post);
           
        });

        await _unitOfWork.CommitAsync();


        return new SingleResponse<Response>(new Response());
    }

    private List<Feed> GetFeed(Sources source)
    {
        var url = new Uri($"{source.Protocol}://{source.Domain}{source.FeedUrl}");

        using var reader = XmlReader.Create(url.ToString() );
        var feed = SyndicationFeed.Load(reader);

        var articles = new List<Feed>();

        feed.Items.ToList().ForEach(y =>
        {
            var article = new Feed()
            {
                Url = y.Links[0].Uri.ToString(),
                Title = y.Title.Text,
                Summary = y.Summary.Text.RemoveHtmlTags(),
                SourceId = source.Id,
                Published = y.PublishDate.UtcDateTime
            };
            articles.Add(article);
        });

        return articles;
    }
}