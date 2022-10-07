
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database.Articless;

internal class ArticlesContextFactory : IDesignTimeDbContextFactory<ArticlesContext>
{
    public ArticlesContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ArticlesContext> dbContextOptionsBuilder =
            new();

        dbContextOptionsBuilder.UseNpgsql(ConnectionStringNames.LocalBuild);
        return new ArticlesContext(dbContextOptionsBuilder.Options);
    }
}
