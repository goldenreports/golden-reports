using GoldenReports.Domain.Data;

namespace GoldenReports.Application.Abstractions.Persistence;

public interface IDataSourceRepository : IRepository<DataSource>
{
    Task<bool> CheckCodeAvailability(string code, CancellationToken cancellationToken = default);
    
    Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default);
    
    Task<bool> CheckNameChange(Guid dataSourceId, string name,
        CancellationToken cancellationToken = default);
}