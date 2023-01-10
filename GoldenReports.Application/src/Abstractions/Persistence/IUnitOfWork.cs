namespace GoldenReports.Application.Abstractions.Persistence;

public interface IUnitOfWork
{
    Task CommitChanges(CancellationToken cancellationToken = default);
}