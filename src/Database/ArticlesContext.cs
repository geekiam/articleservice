using System.Reflection;
using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Threenine;
using Threenine.Configurations.PostgreSql;

namespace Geekiam;

public class ArticlesContext : BaseContext<ArticlesContext>
{
    public ArticlesContext(DbContextOptions<ArticlesContext> options)
        : base(options)
    {
    }

    public DbSet<Sources> Sources { get; set; }

    public DbSet<Posts> Posts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema.Name);
        modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}