using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Configurations;

public class SourceCategoryConfiguration : BaseEntityTypeConfiguration<SourceCategory>
{
    public override void Configure(EntityTypeBuilder<SourceCategory> builder)
    {
        builder.ToTable(nameof(SourceCategory).ToLower());

        builder.HasOne(x => x.Categories)
            .WithMany(p => p.SourceCategories)
            .HasForeignKey(k => k.CategoryId);
        
        builder.HasOne(x => x.Source)
            .WithMany(p => p.SourceCategories)
            .HasForeignKey(k => k.SourceId);
        
        base.Configure(builder);
    }
}