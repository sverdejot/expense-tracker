namespace Domain.Shared.Base;

public abstract class Entity<T> : IEquatable<Entity<T>>, IAuditable
{
    public DateTime ModifiedOnUtc { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public bool Equals(Entity<T>? other)
    {
        if (other is null)
            return false;
        return Equals(other);
    }

    public static bool operator ==(Entity<T>? left, Entity<T>? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right) => !(left == right);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
