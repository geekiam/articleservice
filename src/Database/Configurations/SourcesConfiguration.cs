using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Geekiam.Configurations;

public class SourcesConfiguration : BaseEntityTypeConfiguration<Sources>
{
    public override void Configure(EntityTypeBuilder<Sources> builder)
    {
        builder.ToTable(nameof(Sources).ToLower());

        builder.Property(x => x.Identifier)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300);

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
        
        builder.Property(x => x.Protocol)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(7)
            .IsRequired();

        builder.Property(x => x.LastUpdate)
            .HasColumnType(ColumnTypes.Timestamp);

        builder.Property(x => x.Status)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(15)
            .HasDefaultValue(SourceStatus.Moderate)
            .IsRequired();

        builder.Property(x => x.Media)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(6)
            .HasDefaultValue(Media.Text)
            .IsRequired();

        builder.HasIndex(x => new { x.FeedUrl, x.Domain})
            .IsUnique();

        builder.HasIndex(x => x.Identifier).IsUnique();
        
        base.Configure(builder);
    }
}