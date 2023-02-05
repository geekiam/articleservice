using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Configurations;

public class ContentConfiguration : BaseEntityTypeConfiguration<Content>
{
    public override void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.ToTable(nameof(Content).ToLower());
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75);
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300);
        
        builder.Property(x => x.Image)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75);
        
        builder.Property(x => x.Summary)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75);
        
        base.Configure(builder);
    }
}