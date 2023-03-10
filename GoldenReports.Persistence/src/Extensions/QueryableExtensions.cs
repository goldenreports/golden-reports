using System.Linq.Expressions;
using GoldenReports.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> IncludeAuditInfo<TEntity>(this IQueryable<TEntity> queryable)
        where TEntity : Entity
    {
        return queryable
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy);
    }

    public static IQueryable<TEntity> IncludeWithAuditInfo<TEntity, TProperty>(this IQueryable<TEntity> queryable,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        where TEntity : class
        where TProperty : Entity
    {
        return queryable
            .Include(navigationPropertyPath).ThenInclude(x => x.CreatedBy)
            .Include(navigationPropertyPath).ThenInclude(x => x.ModifiedBy);
    }

    public static IQueryable<TEntity> IncludeWithAuditInfo<TEntity, TProperty>(this IQueryable<TEntity> queryable,
        Expression<Func<TEntity, IEnumerable<TProperty>>> navigationPropertyPath)
        where TEntity : class
        where TProperty : Entity
    {
        return queryable
            .Include(navigationPropertyPath).ThenInclude(x => x.CreatedBy)
            .Include(navigationPropertyPath).ThenInclude(x => x.ModifiedBy);
    }
}
