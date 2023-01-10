using GoldenReports.Domain.Common;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Domain.Reports;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence;

public class GoldenReportsDbContext : DbContext
{
    public GoldenReportsDbContext(DbContextOptions<GoldenReportsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Namespace> Namespaces { get; set; }
    
    public DbSet<DataSource> DataSources { get; set; }

    public DbSet<DataContext> DataContexts { get; set; }

    public override int SaveChanges()
    {
        this.RefreshAuditDates();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        this.RefreshAuditDates();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        this.RefreshAuditDates();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        this.RefreshAuditDates();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        DbInitializer.Initialize(modelBuilder);
    }

    private void RefreshAuditDates()
    {
        foreach (var entry in this.ChangeTracker.Entries<Entity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreationDate = DateTime.UtcNow;
            }

            entry.Entity.ModificationDate = DateTime.UtcNow;
        }
    }
}