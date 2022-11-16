using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;
using Geekiam;
using Geekiam.Websites.Update;

namespace Strategies;

public class UpdateArticleListingStrategy : IStrategy<FeedLink, List<Article>>
{
    public async Task<List<Article>> Execute(FeedLink request, CancellationToken cancellationToken)
    {
        return await GetFeed(request.ToString());
    }

    private static async Task<List<Article>> GetFeed(string source)
    {
        var articles = new List<Article>();
        await Task.Run(() =>
        {
            using var reader = XmlReader.Create(source);
            var feed = SyndicationFeed.Load(reader);
            
            feed.Items.ToList().ForEach(y =>
            {
                var article = new Article
                {
                    Url = y.Links[0].Uri.ToString(),
                    Title = y.Title.Text,
                    Summary = y.Summary.Text.RemoveHtmlTags(),
                    Published = y.PublishDate.UtcDateTime
                };
                articles.Add(article);
            });
        });
        return articles;
    }
}