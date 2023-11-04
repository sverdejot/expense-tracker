using Domain.Shared.Base;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Criteria;

public static class Paginator<TEntity>
    where TEntity : AggregateRoot<TEntity>
{
    public static async Task<Page<TEntity>> GetPage(
        IQueryable<TEntity> query, 
        int index, 
        int size, 
        Criteria<TEntity>? criteria = default)
    {   
        if (criteria is not null)
        {
            query = CriteriaMatcher.GetQuery(query, criteria);
        }

        var totalCount = await query.CountAsync();

        // TODO: sort by a default parameter
        var items = await query
            .Skip((index - 1) * size)
            .Take(size)
            .ToListAsync();

        return Page<TEntity>.Create(items, totalCount, index, size);
    }
}
