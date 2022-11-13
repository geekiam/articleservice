using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Geekiam.Configurations;

public class SourceCategoryConfiguration : BaseEntityTypeConfiguration<SourceCategory>
{
    public override void Configure(EntityTypeBuilder<SourceCategory> builder)
    {
        builder.ToTable(nameof(SourceCategory).ToLower());

        builder.HasOne(x => x.Category)
            .WithMany(p => p.Sources)
            .HasForeignKey(k => k.CategoryId);
        
        builder.HasOne(x => x.Source)
            .WithMany(p => p.Categories)
            .HasForeignKey(k => k.SourceId);
        
        base.Configure(builder);
    }
}