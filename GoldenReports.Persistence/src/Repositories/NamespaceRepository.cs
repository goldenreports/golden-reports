using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Repositories;

public class NamespaceRepository : Repository<Namespace>, INamespaceRepository
{
    private readonly GoldenReportsDbContext dataContext;

    public NamespaceRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public Task<Namespace> GetRootNamespace(CancellationToken cancellationToken = default)
    {
        return this.dataContext.Namespaces.SingleAsync(x => !x.ParentId.HasValue, cancellationToken);
    }

    public async Task<bool> CheckNameAvailability(Guid? parentId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.Namespaces.AnyAsync(
            x =>
                x.ParentId == parentId &&
                x.Name == name,
            cancellationToken);
        return !nameExists;
    }

    public async Task<bool> CheckNameChange(Guid namespaceId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.Namespaces
            .Where(x =>
                x.Id == namespaceId &&
                (x.Parent != null && x.Parent.Namespaces.Any(n => n.Name == name && n.Id != namespaceId) ||
                 x.Parent == null &&
                 this.dataContext.Namespaces.Any(n => n.Parent == null && n.Name == name && n.Id != namespaceId))
            ).AnyAsync(cancellationToken);
        return !nameExists;
    }

    public Task<Namespace?> GetNamespaceWithInnerNamespaces(Guid namespaceId,
        CancellationToken cancellationToken = default)
    {
        return this.dataContext.Namespaces
            .IncludeWithAuditInfo(x => x.Namespaces)
            .IncludeAuditInfo()
            .SingleOrDefaultAsync(x => x.Id == namespaceId, cancellationToken);
    }

    public Task<Namespace?> GetNamespaceWithDataSources(Guid namespaceId, CancellationToken cancellationToken = default)
    {
        return this.dataContext.Namespaces
            .IncludeWithAuditInfo(x => x.DataSources)
            .IncludeAuditInfo()
            .SingleOrDefaultAsync(x => x.Id == namespaceId, cancellationToken);
    }

    public Task<Namespace?> GetNamespaceWithDataContexts(Guid namespaceId,
        CancellationToken cancellationToken = default)
    {
        return this.dataContext.Namespaces
            .IncludeWithAuditInfo(x => x.DataContexts)
            .IncludeAuditInfo()
            .SingleOrDefaultAsync(x => x.Id == namespaceId, cancellationToken);
    }

    public Task<Namespace?> GetNamespaceWithReports(Guid namespaceId, CancellationToken cancellationToken = default)
    {
        return this.dataContext.Namespaces
            .IncludeWithAuditInfo(x => x.Reports)
            .IncludeAuditInfo()
            .SingleOrDefaultAsync(x => x.Id == namespaceId, cancellationToken);
    }

    public IAsyncEnumerable<Namespace> GetAncestors(Guid namespaceId)
    {
        return this.dataContext.Namespaces
            .FromSqlRaw(@"
                WITH RECURSIVE namespace_ancestry AS (
                    SELECT
                        id_namespace,
                        id_parent,
                        name,
                        description,
                        creation_date,
                        id_created_by,
                        modification_date,
                        id_modified_by
                    FROM
                        golden_reports.namespace WHERE id_namespace = {0}
                    UNION
                    SELECT
                        n.id_namespace,
                        n.id_parent,
                        n.name,
                        n.description,
                        n.creation_date,
                        n.id_created_by,
                        n.modification_date,
                        n.id_modified_by
                    FROM
                        golden_reports.namespace n
                    INNER JOIN namespace_ancestry a ON n.id_namespace = a.id_parent
                )
                SELECT * FROM namespace_ancestry WHERE id_namespace != {0}
            ", namespaceId)
            .AsNoTrackingWithIdentityResolution()
            .AsAsyncEnumerable();
    }
}
