using GoldenReports.Domain.Assets;

namespace GoldenReports.Application.Abstractions.Persistence;

public interface INamespaceAssetRepository : IRepository<NamespaceAsset>
{
    Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<NamespaceAsset> GetRootNamespaceAssets();
}