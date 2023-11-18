namespace Application.Groups;

public record GroupDTO(Guid Id, string Name, Guid Admin, List<Guid> Members, List<GroupRecordDTO> Records);
