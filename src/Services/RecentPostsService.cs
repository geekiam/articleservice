using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Update;
using Threenine.Data;

namespace Services;

public class RecentPostsService : IProcessService<Article, Sources>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecentPostsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task Process(List<Article> items, Sources source)
    {
        items.ForEach(article =>
        {
            var post = _mapper.Map<Posts>(article);
            post.SourceId = source.Id;
            _unitOfWork.GetRepository<Posts>()
                .InsertNotExists(item => item.SourceId.Equals(post.SourceId) && item.Permalink.Equals(post.Permalink),
                    post);
        });
        
        source.LastUpdate = DateTime.UtcNow;
        _unitOfWork.GetRepository<Sources>().Update(source); 
        await _unitOfWork.CommitAsync();
    }
}