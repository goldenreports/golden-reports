using GoldenReports.Application.Abstractions.Persistence;

namespace GoldenReports.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly GoldenReportsDbContext applicationDbContext;

    public UnitOfWork(GoldenReportsDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public Task CommitChanges(CancellationToken cancellationToken = default)
    {
        return this.applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}