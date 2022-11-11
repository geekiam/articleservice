using Geekiam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Database.Configurations;

public class CategoriesConfiguration : BaseEntityTypeConfiguration<Categories>
{
    public override void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.ToTable(nameof(Categories).ToLower());

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(65);

        builder.Property(x => x.Permalink)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255);

        base.Configure(builder);
    }
}