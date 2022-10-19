using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Configurations;

public class SourcesConfiguration : BaseEntityTypeConfiguration<Sources>
{
    public override void Configure(EntityTypeBuilder<Sources> builder)
    {
        builder.ToTable(nameof(Sources).ToLower());
        
        
        builder.Property(x => x.Name)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.Domain)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.FeedUrl)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(x => x.FeedUrl)
            .IsUnique();
        
        base.Configure(builder);
    }
}