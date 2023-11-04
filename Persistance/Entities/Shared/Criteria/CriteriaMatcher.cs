using Domain.Shared.Base;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Criteria;

public static class CriteriaMatcher
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> input,
        Criteria<TEntity> criteria)
        where TEntity : Entity<TEntity>
    {
        IQueryable<TEntity> queryable = input;

        if (criteria.Where is not null)
        {
            queryable = queryable.Where(criteria.Where);
        }

        criteria.Include.Aggregate(queryable, 
            (current, include) => {
                current = current.Include(include);
                return current;
            });

        if (criteria.OrderByAscExpression is not null)
        {
            queryable = queryable.OrderBy(criteria.OrderByAscExpression);
        }
        else if (criteria.OrderByDescExpression is not null)
        {
            queryable = queryable.OrderByDescending(criteria.OrderByDescExpression);
        }

        return queryable;
    }
}
