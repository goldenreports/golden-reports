using GoldenReports.Application.Constants;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Data;

public class DataContextConfiguration : EntityTypeConfiguration<DataContext>
{
    public override void Configure(EntityTypeBuilder<DataContext> builder)
    {
        builder.ApplyEntityConfiguration();
        builder.HasIndex(x => new { x.NamespaceId, x.Name }).IsUnique().HasDatabaseName("IX_DataContext_Name");
        builder.Property(x => x.NamespaceId).HasColumnName(this.NameConverter.GetColumnName("IdNamespace"));
        builder.Property(x => x.Name).HasMaxLength(StringSizes.Small);
        builder.Property(x => x.Schema).HasMaxLength(StringSizes.ExtraLarge);
        builder.HasOne(x => x.Namespace).WithMany(x => x.DataContexts).HasForeignKey(x => x.NamespaceId)
            .HasConstraintName($"FK_{nameof(DataContext)}_{nameof(Namespace)}");
    }
}
