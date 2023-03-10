using System.Linq.Expressions;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Common;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly GoldenReportsDbContext dataContext;

    public Repository(GoldenReportsDbContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public virtual ValueTask<TEntity?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return this.dataContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual IAsyncEnumerable<TEntity> GetAll()
    {
        return this.dataContext.Set<TEntity>()
            .OrderByDescending(x => x.ModificationDate)
            .IncludeAuditInfo()
            .AsAsyncEnumerable();
    }

    public virtual IAsyncEnumerable<TEntity> GetAllAsReadOnly()
    {
        return this.dataContext.Set<TEntity>()
            .OrderByDescending(x => x.ModificationDate)
            .IncludeAuditInfo()
            .AsNoTrackingWithIdentityResolution()
            .AsAsyncEnumerable();
    }

    public virtual IAsyncEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return this.dataContext.Set<TEntity>()
            .Where(predicate)
            .IncludeAuditInfo()
            .OrderByDescending(x => x.ModificationDate)
            .AsAsyncEnumerable();
    }

    public IAsyncEnumerable<TEntity> FindAsReadOnly(Expression<Func<TEntity, bool>> predicate)
    {
        return this.dataContext.Set<TEntity>()
            .Where(predicate)
            .IncludeAuditInfo()
            .OrderByDescending(x => x.ModificationDate)
            .AsNoTrackingWithIdentityResolution()
            .AsAsyncEnumerable();
    }

    public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        await this.dataContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public virtual Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return this.dataContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public virtual void Remove(TEntity entity)
    {
        this.dataContext.Set<TEntity>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        this.dataContext.Set<TEntity>().RemoveRange(entities);
    }
}
