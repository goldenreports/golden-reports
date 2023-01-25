using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Repositories;

public class DataContextRepository : Repository<DataContext>, IDataContextRepository
{
    private readonly GoldenReportsDbContext dataContext;

    public DataContextRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<bool> CheckNameAvailability(Guid namespaceId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.DataContexts.AnyAsync(
            x =>
                x.NamespaceId == namespaceId &&
                x.Name == name,
            cancellationToken
        );

        return !nameExists;
    }

    public async Task<bool> CheckNameChange(Guid dataContextId, string name,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await this.dataContext.DataContexts
            .Where(x => x.Id == dataContextId)
            .AnyAsync(x => x.Namespace.DataContexts.Any(c => c.Name == name && c.Id != dataContextId),
                cancellationToken);

        return !nameExists;
    }
}