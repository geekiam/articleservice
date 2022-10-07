using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Threenine;

namespace Database.Articless;

public class ArticlesContext : BaseContext<ArticlesContext>
{
    public ArticlesContext(DbContextOptions<ArticlesContext> options)
        : base(options)
    {
    }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema.Name);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}