namespace Domain;

public interface IAuditable
{
    DateTime ModifiedOnUtc { get; set; }

    DateTime CreatedOnUtc { get; set; }
}
