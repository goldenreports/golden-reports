using GoldenReports.Application.Constants;
using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Reports;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Assets;

public class ReportAssetConfiguration : EntityTypeConfiguration<ReportAsset>
{
    public override void Configure(EntityTypeBuilder<ReportAsset> builder)
    {
        builder.ApplyEntityConfiguration();
        builder.HasAlternateKey(x => new { x.ReportId, x.Name }).HasName("UK_ReportAsset_Name");
        builder.Property(x => x.ReportId).HasColumnName(this.NameConverter.GetColumnName("IdReport"));
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Path).HasMaxLength(StringSizes.Medium);
        builder.HasOne(x => x.Report).WithMany(x => x.Assets).HasForeignKey(x => x.ReportId)
            .HasConstraintName($"FK_{nameof(ReportAsset)}_{nameof(ReportDefinition)}");
    }
}
