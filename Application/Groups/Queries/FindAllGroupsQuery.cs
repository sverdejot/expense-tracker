using Application.Shared.Query;

namespace Application.Groups;

public sealed record FindAllGroupsQuery() : IQuery<List<GroupDTO>>;
