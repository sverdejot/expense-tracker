namespace Domain.Shared.Base;

public interface IRepository<TEntity>
    where TEntity : AggregateRoot<TEntity>
{
    public Task Add(TEntity entity);

    public Task<List<TEntity>> Match(Criteria<TEntity> criteria);

    public Task<TEntity> MatchFirst(Criteria<TEntity> criteria);

    public Task<Page<TEntity>> MatchPage(Criteria<TEntity> criteria, int index, int size);

    public Task<TEntity?> MatchFirstOrDefault(Criteria<TEntity> criteria);

    public Task<Page<TEntity>> GetPage(int index, int size);
}
