using GoldenReports.Application.Constants;
using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Assets;

public class NamespaceAssetConfiguration : EntityTypeConfiguration<NamespaceAsset>
{
    public override void Configure(EntityTypeBuilder<NamespaceAsset> builder)
    {
        builder.ApplyEntityConfiguration(this.NameConverter);
        builder.HasAlternateKey(x => new { x.NamespaceId, x.Name }).HasName("UK_NamespaceAsset_Name");
        builder.Property(x => x.NamespaceId).HasColumnName(this.NameConverter.GetColumnName("IdNamespace"));
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Path).HasMaxLength(StringSizes.Medium);
        builder.HasOne(x => x.Namespace).WithMany(x => x.Assets).HasForeignKey(x => x.NamespaceId)
            .HasConstraintName($"FK_{nameof(NamespaceAsset)}_{nameof(Namespace)}");
    }
}
