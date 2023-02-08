using GoldenReports.Application.Constants;
using GoldenReports.Domain.Reports;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Reports;

public class ReportParameterConfiguration : EntityTypeConfiguration<ReportParameter>
{
    public override void Configure(EntityTypeBuilder<ReportParameter> builder)
    {
        builder.ApplyEntityConfiguration();
        builder.HasIndex(x => new { x.ReportId, x.Name }).IsUnique().HasDatabaseName("UK_ReportParameter_Name");
        builder.Property(x => x.ReportId).HasColumnName(this.NameConverter.GetColumnName("IdReport"));
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Type).HasDefaultValue(ScalarType.Text);
        builder.Property(x => x.Required).HasDefaultValue(false);
        builder.HasOne(x => x.Report).WithMany(x => x.Parameters).HasForeignKey(x => x.ReportId)
            .HasConstraintName($"FK_{nameof(ReportParameter)}_{nameof(ReportDefinition)}");
    }
}
