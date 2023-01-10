using GoldenReports.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static void ApplyBasicEntityConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string? tableName = null) where TEntity: class
    {
        var entityName = tableName ?? typeof(TEntity).Name;
        builder.ToTable(entityName.ToSnakeCase(), "GoldenReports".ToSnakeCase());
    }
    
    public static void ApplyIdentifiableConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName) where TEntity: class, IIdentifiable
    {
        builder.HasKey(x => x.Id).HasName($"PK_{tableName}");
        builder.Property(x => x.Id).HasColumnName($"Id{tableName}".ToSnakeCase());
    }

    public static void ApplyAuditableConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName)
        where TEntity : class, IAuditable
    {
        // builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey("IdCreatedBy")
        //     .HasConstraintName($"FK_{tableName}_User_CreatedBy");
        // builder.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey("IdModifiedBy")
        //     .HasConstraintName($"FK_{tableName}_User_ModifiedBy");
    }

    public static void ApplyEntityConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder, string? tableName = null)
        where TEntity : Entity
    {
        var entityName = tableName ?? typeof(TEntity).Name;
        builder.ApplyBasicEntityConfiguration(entityName);
        builder.ApplyIdentifiableConfiguration(entityName);
        builder.ApplyAuditableConfiguration(entityName);
    }
}