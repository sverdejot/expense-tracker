using Domain.Shared.Base;

namespace Domain;

public class InvalidTotalPercentageException : DomainException
{
    public InvalidTotalPercentageException(List<RecordPercentage> percentages) : base(
        $"The total sum of the percentages does not add up to 1 (100%). The current values are: [{FormatPercentages(percentages)}]")
        
    {
    }

    private static string FormatPercentages(List<RecordPercentage> percentages) =>
        String.Join(", ", percentages.Select(percentage => percentage.Percentage).ToArray());
}
