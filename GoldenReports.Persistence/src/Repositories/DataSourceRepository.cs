using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Repositories;

public class DataSourceRepository : Repository<DataSource>, IDataSourceRepository
{
    private readonly GoldenReportsDbContext dataContext;

    public DataSourceRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<bool> CheckCodeAvailability(string code, CancellationToken cancellationToken = default)
    {
        var codeExists = await this.dataContext.DataSources.AnyAsync(x => x.Code == code, cancellationToken);
        return !codeExists;
    }

    public async Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.DataSources.AnyAsync(
            x =>
                x.NamespaceId == namespaceId &&
                x.Name == name,
            cancellationToken
        );

        return !nameExists;
    }

    public async Task<bool> CheckNameChange(Guid dataSourceId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.DataSources
            .Where(x => x.Id == dataSourceId)
            .AnyAsync(x => x.Namespace.DataSources.Any(s => s.Name == name && s.Id != dataSourceId),
                cancellationToken
            );

        return !nameExists;
    }
}