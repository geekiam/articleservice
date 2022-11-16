using AutoMapper;
using Geekiam.Data;
using Geekiam.Feeds.Update;
using Threenine.Data;

namespace Services;

public class RecentPostsService : IProcessService<Posts, Sources>
{
    private readonly IUnitOfWork _unitOfWork;

    public RecentPostsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Process(List<Posts> items, Sources source)
    {
        items.ForEach(post =>
        {
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