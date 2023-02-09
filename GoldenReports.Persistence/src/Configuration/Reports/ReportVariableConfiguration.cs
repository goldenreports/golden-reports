using GoldenReports.Application.Constants;
using GoldenReports.Domain.Reports;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Reports;

public class ReportVariableConfiguration : EntityTypeConfiguration<ReportVariable>
{
    public override void Configure(EntityTypeBuilder<ReportVariable> builder)
    {
        builder.ApplyEntityConfiguration(this.NameConverter);
        builder.HasIndex(x => new { x.ReportId, x.Name }).IsUnique().HasDatabaseName("UK_ReportVariable_Name");
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Expression).HasMaxLength(StringSizes.Medium);
        builder.Property(x => x.ReportId).HasColumnName(this.NameConverter.GetColumnName("IdReport"));
        builder.HasOne(x => x.Report).WithMany(x => x.Variables).HasForeignKey(x => x.ReportId)
            .HasConstraintName($"FK_{nameof(ReportVariable)}_{nameof(ReportDefinition)}");
    }
}
