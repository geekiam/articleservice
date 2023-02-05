using System.ComponentModel.DataAnnotations;
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
    
    public DbSet<Content> Contents { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema.Name);
        modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .Select(e => e.Entity).ToList().ForEach(entity =>
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            });

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
         ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .Select(e => e.Entity).ToList().ForEach(entity =>
        {
            var validationContext = new ValidationContext(entity);
            Validator.ValidateObject(
                entity,
                validationContext,
                validateAllProperties: true);
        });

        return base.SaveChangesAsync(cancellationToken);
    }
    
}