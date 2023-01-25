using GoldenReports.Domain.Data;

namespace GoldenReports.Application.Abstractions.Persistence;

public interface IDataContextRepository : IRepository<DataContext>
{
    Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default);
    
    Task<bool> CheckNameChange(Guid dataContextId, string name,
        CancellationToken cancellationToken = default);
}