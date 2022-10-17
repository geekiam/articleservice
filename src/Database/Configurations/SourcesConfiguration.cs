using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Articless.Configurations;

public class SourcesConfiguration : BaseEntityTypeConfiguration<Sources>
{
    public override void Configure(EntityTypeBuilder<Sources> builder)
    {
        builder.ToTable(nameof(Sources).ToLower());
        
        
        builder.Property(x => x.Name)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.RootUrl)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.FeedUrl)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired(); 
        
        
        base.Configure(builder);
    }
}