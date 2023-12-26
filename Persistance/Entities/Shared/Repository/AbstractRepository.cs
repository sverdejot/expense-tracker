using Domain.Shared.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.Criteria;


namespace Persistance.Shared;

internal abstract class AbstractRepository<TEntity> : IRepository<TEntity>
    where TEntity : AggregateRoot<TEntity>
{
    protected readonly ApplicationDbContext _context;

    public AbstractRepository(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
    }

    public async Task Add(TEntity entity) =>
        await _context.Set<TEntity>().AddAsync(entity);

    public async Task<List<TEntity>> Match(Criteria<TEntity> criteria) =>
        await ApplyCriteria(criteria).ToListAsync();

    public async Task<TEntity> MatchFirst(Criteria<TEntity> criteria) => 
        await ApplyCriteria(criteria).FirstAsync();

    public async Task<TEntity?> MatchFirstOrDefault(Criteria<TEntity> criteria) =>
        await ApplyCriteria(criteria).FirstOrDefaultAsync();

    public async Task<Page<TEntity>> MatchPage(Criteria<TEntity> criteria, int index, int size) =>
        await Paginator<TEntity>.GetPage(this._context.Set<TEntity>(), index, size, criteria);

    public async Task<Page<TEntity>> GetPage(int index, int size) =>
        await Paginator<TEntity>.GetPage(this._context.Set<TEntity>(), index, size);

    private IQueryable<TEntity> ApplyCriteria(Criteria<TEntity> criteria) => 
        CriteriaMatcher.GetQuery(this._context.Set<TEntity>(), criteria);
}
