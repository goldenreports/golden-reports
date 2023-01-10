using GoldenReports.Domain.Data;

namespace GoldenReports.Application.Abstractions.Persistence;

public interface IDataSourceRepository : IRepository<DataSource>
{
    public Task<bool> CheckCodeAvailability(string code, CancellationToken cancellationToken = default);
    
    public Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default);
    
    public Task<bool> CheckNameChange(Guid dataSourceId, string name,
        CancellationToken cancellationToken = default);
}