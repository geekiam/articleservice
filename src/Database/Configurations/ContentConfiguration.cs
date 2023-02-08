using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Threenine.Configurations.PostgreSql;

namespace Database.Configurations;

public class ContentConfiguration : BaseEntityTypeConfiguration<Content>
{
    public override void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.ToTable(nameof(Content).ToLower());
        builder.Property(x => x.PostId)
            .IsRequired()
            .HasColumnType(ColumnTypes.UniqueIdentifier);

        builder.Property(x => x.Image)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75);
        
        builder.Property(x => x.Summary)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(150);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Contents)
            .HasForeignKey(k => k.PostId);

        base.Configure(builder);
    }
}