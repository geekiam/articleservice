using System.Reflection;
using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Threenine;
using Threenine.Configurations.PostgreSql;

namespace Database.Articless;

public class ArticlesContext : BaseContext<ArticlesContext>
{
    public ArticlesContext(DbContextOptions<ArticlesContext> options)
        : base(options)
    {
    }

    public DbSet<Websites> Websites { get; set; }

    public DbSet<Articles> Articles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema.Name);
        modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}