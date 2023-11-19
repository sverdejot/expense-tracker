namespace Application.Groups;

public record GroupRecordDTO(Decimal Amount, Guid Creator, Dictionary<Guid, Decimal> Percentages);
