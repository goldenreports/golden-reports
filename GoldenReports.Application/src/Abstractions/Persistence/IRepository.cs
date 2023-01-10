using System.Linq.Expressions;
using GoldenReports.Domain.Common;

namespace GoldenReports.Application.Abstractions.Persistence;

public interface IRepository<TEntity> where TEntity : Entity
{
    ValueTask<TEntity?> Get(Guid id, CancellationToken cancellationToken = default);

    IAsyncEnumerable<TEntity> GetAll();
    
    IAsyncEnumerable<TEntity> GetAllAsReadOnly();

    IAsyncEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    
    IAsyncEnumerable<TEntity> FindAsReadOnly(Expression<Func<TEntity, bool>> predicate);

    Task Add(TEntity entity, CancellationToken cancellationToken = default);

    Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);
}