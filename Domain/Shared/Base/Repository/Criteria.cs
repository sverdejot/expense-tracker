using System.Linq.Expressions;

namespace Domain.Shared.Base;

public abstract class Criteria<TEntity>
    where TEntity : Entity<TEntity>
{
    protected Criteria(Expression<Func<TEntity, bool>>? where)
    {
        Where = where;
    }

    public Expression<Func<TEntity, bool>>? Where { get; }

    public List<Expression<Func<TEntity, object>>> Include { get; } = new();

    public Expression<Func<TEntity, object>>? OrderByAscExpression { get; private set; }

    public Expression<Func<TEntity, object>>? OrderByDescExpression { get; private set; }

    protected void AddInclude(Expression<Func<TEntity, object>> expression) =>
        Include.Add(expression);

    protected void AddOrderByAsc(Expression<Func<TEntity, object>>? orderByAscExpression) =>
        OrderByAscExpression = orderByAscExpression;

    protected void AddOrderByDesc(Expression<Func<TEntity, object>>? orderByDescExpression) =>
        OrderByDescExpression = orderByDescExpression;
}
