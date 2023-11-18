namespace Application.Groups;

public record GroupRecordDTO(Decimal Amount, Guid Creator, List<PercentageDTO> Percentages);
