using GoldenReports.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GoldenReports.Persistence.Middlewares;

public interface IDbContextMiddleware
{
    Task ProcessModifiedEntries(GoldenReportsDbContext dbContext, IEnumerable<EntityEntry<Entity>> modifiedEntries);
}