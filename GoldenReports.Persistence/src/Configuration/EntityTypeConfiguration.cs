using GoldenReports.Persistence.Abstractions;
using GoldenReports.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenReports.Persistence.Configuration;

public abstract class EntityTypeConfiguration
{
    public abstract void Configure(IServiceProvider serviceProvider, ModelBuilder modelBuilder);
}

public abstract class EntityTypeConfiguration<TEntity> : EntityTypeConfiguration, IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    public IServiceProvider ServiceProvider { get; private set; } = null!;

    public INameConverter NameConverter =>
        this.ServiceProvider.GetService<INameConverter>() ?? DefaultNameConverter.Instance;

    public override void Configure(IServiceProvider serviceProvider, ModelBuilder modelBuilder)
    {
        this.ServiceProvider = serviceProvider;
        modelBuilder.Entity<TEntity>(Configure);
    }

    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}
