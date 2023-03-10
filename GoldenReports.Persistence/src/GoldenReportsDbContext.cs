using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Domain.Reports;
using GoldenReports.Domain.Security;
using GoldenReports.Persistence.Configuration;
using GoldenReports.Persistence.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence;

public class GoldenReportsDbContext : DbContext
{
    private readonly IEnumerable<IDbContextMiddleware> middlewares;
    private readonly IServiceProvider serviceProvider;
    private readonly IEnumerable<EntityTypeConfiguration> configurations;

    public GoldenReportsDbContext(
        DbContextOptions<GoldenReportsDbContext> options,
        IEnumerable<IDbContextMiddleware> middlewares,
        IServiceProvider serviceProvider,
        IEnumerable<EntityTypeConfiguration> configurations) : base(options)
    {
        this.middlewares = middlewares;
        this.serviceProvider = serviceProvider;
        this.configurations = configurations;
    }

    public DbSet<Namespace> Namespaces { get; set; }

    public DbSet<DataSource> DataSources { get; set; }

    public DbSet<DataContext> DataContexts { get; set; }

    public DbSet<ReportDefinition> Reports { get; set; }

    public DbSet<NamespaceAsset> NamespaceAssets { get; set; }

    public DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        this.ProcessMiddlewares().GetAwaiter().GetResult();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        this.ProcessMiddlewares().GetAwaiter().GetResult();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        await this.ProcessMiddlewares();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        await this.ProcessMiddlewares();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var configuration in this.configurations)
        {
            configuration.Configure(this.serviceProvider, modelBuilder);
        }
        DbInitializer.Initialize(modelBuilder);
    }

    private async Task ProcessMiddlewares()
    {
        var entries = this.ChangeTracker.Entries<Entity>()
            .Where(entry => entry.State != EntityState.Detached && entry.State != EntityState.Unchanged)
            .ToList();

        foreach (var middleware in this.middlewares)
        {
            await middleware.ProcessModifiedEntries(this, entries);
        }
    }
}
