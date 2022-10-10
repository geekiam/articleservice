using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Articless.Configurations;

public class WebsiteConfiguration : BaseEntityTypeConfiguration<Websites>
{
    public override void Configure(EntityTypeBuilder<Websites> builder)
    {
        builder.ToTable(nameof(Websites).ToLower());

        builder.Property(x => x.Identifier)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(25)
            .IsRequired();
        
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