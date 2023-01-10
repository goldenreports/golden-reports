using GoldenReports.Application.Constants;
using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Assets;

public class NamespaceAssetConfiguration : IEntityTypeConfiguration<NamespaceAsset>
{
    public void Configure(EntityTypeBuilder<NamespaceAsset> builder)
    {
        builder.ApplyEntityConfiguration();
        builder.HasAlternateKey(x => new {x.NamespaceId, x.Name}).HasName("UK_NamespaceAsset_Name");
        builder.Property(x => x.NamespaceId).HasColumnName("IdNamespace".ToSnakeCase());
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Path).HasMaxLength(StringSizes.Medium);
        builder.HasOne(x => x.Namespace).WithMany(x => x.Assets).HasForeignKey(x => x.NamespaceId)
            .HasConstraintName($"FK_{nameof(NamespaceAsset)}_{nameof(Namespace)}");
    }
}