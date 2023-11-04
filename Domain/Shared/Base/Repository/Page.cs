namespace Domain.Shared.Base;

public class Page<TEntity>
    where TEntity : AggregateRoot<TEntity>
{
    private Page(List<TEntity> items, int total, int index, int size)
    {
        Items = items;
        Total = total;
        Index = index;
        Size = size;
    }

    public List<TEntity> Items { get; } = new();

    public int Index { get; set; }

    public int Size { get; set; }

    public int Total { get; set; }

    public bool HasNext => Index * Size < Total;

    public bool HasPrevious => Index > 1;

    public static Page<TEntity> Create(List<TEntity> items, int total ,int index, int size)
    {
        return new(items, total, index, size);
    }
}
