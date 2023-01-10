using GoldenReports.Application.Constants;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Domain.Reports;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Reports;

public class ReportDefinitionConfiguration : IEntityTypeConfiguration<ReportDefinition>
{
    public void Configure(EntityTypeBuilder<ReportDefinition> builder)
    {
        builder.ApplyEntityConfiguration();
        builder.HasIndex(x => new {x.NamespaceId, x.Name}).IsUnique().HasDatabaseName("IX_ReportDefinition_Name");
        builder.Property(x => x.NamespaceId).HasColumnName("IdNamespace".ToSnakeCase());
        builder.Property(x => x.ParentId).HasColumnName("IdParent".ToSnakeCase());
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Description).HasMaxLength(StringSizes.Small);
        builder.Property(x => x.Query).HasMaxLength(StringSizes.Large);
        builder.Property(x => x.Styles).HasMaxLength(StringSizes.Large);
        builder.HasOne(x => x.Namespace).WithMany(x => x.Reports).HasForeignKey(x => x.NamespaceId)
            .HasConstraintName($"FK_{nameof(ReportDefinition)}_{nameof(Namespace)}");
        builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId)
            .HasConstraintName($"FK_{nameof(ReportDefinition)}_{nameof(ReportDefinition)}Parent");
    }
}