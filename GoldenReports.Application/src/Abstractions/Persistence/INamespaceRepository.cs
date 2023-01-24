using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Application.Abstractions.Persistence;

public interface INamespaceRepository : IRepository<Namespace>
{
    Task<Namespace> GetRootNamespace(CancellationToken cancellationToken = default);

    public Task<bool> CheckNameAvailability(Guid? parentId, string name,
        CancellationToken cancellationToken = default);
    
    public Task<bool> CheckNameChange(Guid namespaceId, string name,
        CancellationToken cancellationToken = default);

    Task<Namespace?> GetNamespaceWithInnerNamespaces(Guid namespaceId, CancellationToken cancellationToken = default);

    Task<Namespace?> GetNamespaceWithDataSources(Guid namespaceId, CancellationToken cancellationToken = default);

    Task<Namespace?> GetNamespaceWithDataContexts(Guid namespaceId, CancellationToken cancellationToken = default);

    Task<Namespace?> GetNamespaceWithReports(Guid namespaceId, CancellationToken cancellationToken = default);

    IAsyncEnumerable<Namespace> GetAncestors(Guid namespaceId);
}