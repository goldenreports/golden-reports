using GoldenReports.Application.Constants;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Data;

public class DataSourceConfiguration : EntityTypeConfiguration<DataSource>
{
    public override void Configure(EntityTypeBuilder<DataSource> builder)
    {
        builder.ApplyEntityConfiguration(this.NameConverter);
        builder.HasIndex(x => x.Code).IsUnique().HasDatabaseName("IX_DataSource_Code");
        builder.HasIndex(x => new { x.NamespaceId, x.Name }).IsUnique().HasDatabaseName("IX_DataSource_Name");
        builder.Property(x => x.Code).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Name).HasMaxLength(StringSizes.Small);
        builder.Property(x => x.Description).HasMaxLength(StringSizes.Medium);
        builder.Property(x => x.ConnectionString).HasMaxLength(StringSizes.Medium);
        builder.Property(x => x.NamespaceId).HasColumnName(this.NameConverter.GetColumnName("IdNamespace"));
        builder.HasOne(x => x.Namespace).WithMany(x => x.DataSources).HasForeignKey(x => x.NamespaceId)
            .HasConstraintName($"FK_{nameof(DataSource)}_{nameof(Namespace)}");
    }
}
