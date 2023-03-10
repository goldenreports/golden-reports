using GoldenReports.Application.Constants;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Namespaces;

public class NamespaceConfiguration : EntityTypeConfiguration<Namespace>
{
    public override void Configure(EntityTypeBuilder<Namespace> builder)
    {
        builder.ApplyEntityConfiguration(this.NameConverter);
        builder.HasIndex(x => new { x.ParentId, x.Name }).IsUnique().HasDatabaseName("IX_Namespace_Name");
        builder.Property(x => x.Name).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Description).HasMaxLength(StringSizes.Small);
        builder.Property(x => x.ParentId).HasColumnName(this.NameConverter.GetColumnName("IdParent"));
        builder.HasOne(x => x.Parent).WithMany(x => x.Namespaces).HasForeignKey(x => x.ParentId)
            .HasConstraintName($"FK_{nameof(Namespace)}_{nameof(Namespace)}");
    }
}
