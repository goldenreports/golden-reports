using GoldenReports.Domain.Common;
using GoldenReports.Persistence.Abstractions;
using GoldenReports.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static void ApplyBasicEntityConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, INameConverter? nameConverter = null, string? tableName = null) where TEntity : class
    {
        nameConverter ??= DefaultNameConverter.Instance;
        var entityName = tableName ?? typeof(TEntity).Name;
        builder.ToTable(nameConverter.GetTableName(entityName), nameConverter.GetSchemaName("GoldenReports"));
    }

    public static void ApplyIdentifiableConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, INameConverter? nameConverter = null, string? tableName = null) where TEntity : class, IIdentifiable
    {
        nameConverter ??= DefaultNameConverter.Instance;
        tableName ??= typeof(TEntity).Name;
        builder.HasKey(x => x.Id).HasName($"PK_{tableName}");
        builder.Property(x => x.Id).HasColumnName(nameConverter.GetColumnName($"Id{tableName}"));
    }

    public static void ApplyAuditableConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, INameConverter nameConverter, string tableName)
        where TEntity : class, IAuditable
    {
        builder.Property(x => x.CreatedById).HasColumnName(nameConverter.GetColumnName("IdCreatedBy"));
        builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById)
            .HasConstraintName($"FK_{tableName}_User_CreatedBy");
        builder.Property(x => x.ModifiedById).HasColumnName(nameConverter.GetColumnName("IdModifiedBy"));
        builder.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById)
            .HasConstraintName($"FK_{tableName}_User_ModifiedBy");
    }

    public static void ApplyEntityConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, INameConverter? nameConverter = null, string? tableName = null)
        where TEntity : Entity
    {
        nameConverter ??= DefaultNameConverter.Instance;
        var entityName = tableName ?? typeof(TEntity).Name;
        builder.ApplyBasicEntityConfiguration(nameConverter, entityName);
        builder.ApplyIdentifiableConfiguration(nameConverter, entityName);
        builder.ApplyAuditableConfiguration(nameConverter, entityName);
    }
}
