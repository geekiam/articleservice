using System.ServiceModel.Syndication;
using System.Xml;
using AutoMapper;
using Common;
using Geekiam.Data;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace Geekiam.Activities.Processes.Commands.Process;

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


        var url = new Uri($"{website.Protocol}://{website.Domain}{website.FeedUrl}");

        using var reader = XmlReader.Create(url.ToString());
        var feed = SyndicationFeed.Load(reader);

      

        feed.Items.ToList().ForEach(y =>
        {
            var posts = new Posts
            {
                Permalink = y.Links[0].Uri.ToString(),
                Title = y.Title.Text,
                Summary = y.Summary.Text.RemoveHtmlTags(),
                SourceId = website.Id,
                Published = y.PublishDate.UtcDateTime
            };
        

            _unitOfWork.GetRepository<Posts>()
                .InsertNotExists(post => post.SourceId.Equals(posts.SourceId) && post.Permalink.Equals(posts.Permalink),
                    posts);
        });
        await _unitOfWork.CommitAsync();


        return new SingleResponse<Response>(new Response());
    }
}