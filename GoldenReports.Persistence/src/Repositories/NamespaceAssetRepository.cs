using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Assets;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Repositories;

public class NamespaceAssetRepository : Repository<NamespaceAsset>, INamespaceAssetRepository
{
    private readonly GoldenReportsDbContext dataContext;

    public NamespaceAssetRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.NamespaceAssets.AnyAsync(
            x =>
                x.NamespaceId == namespaceId &&
                x.Name == name,
            cancellationToken
        );

        return !nameExists;
    }

    public IAsyncEnumerable<NamespaceAsset> GetRootNamespaceAssets()
    {
        return this.dataContext.NamespaceAssets
            .Where(x => x.Namespace.ParentId == null)
            .AsNoTracking()
            .AsAsyncEnumerable();
    }
}