using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Articless.Configurations;

public class ArticlesConfiguration : Threenine.Configurations.SqlServer.BaseEntityTypeConfiguration<Articles>
{
   public override void Configure(EntityTypeBuilder<Articles> builder)
   {
      builder.ToTable(nameof(Websites).ToLower());

      builder.Property(x => x.Title)
         .HasColumnType(ColumnTypes.Varchar)
         .HasMaxLength(255)
         .IsRequired();
      
      builder.Property(x => x.Summary)
         .HasColumnType(ColumnTypes.Varchar)
         .HasMaxLength(300)
         .IsRequired();
      
      builder.Property(x => x.Permalink)
         .HasColumnType(ColumnTypes.Varchar)
         .HasMaxLength(255)
         .IsRequired();
      
      
      builder.Property(x => x.Published)
         .HasColumnType(ColumnTypes.Timestamp)
         .IsRequired();
      
      builder.Property(x => x.WebsiteId)
         .HasColumnType(ColumnTypes.UniqueIdentifier)
       .IsRequired();

      builder.HasOne(x => x.Website)
         .WithMany(x => x.Articles)
         .HasForeignKey(x => x.WebsiteId);
      
      base.Configure(builder);
   }
}