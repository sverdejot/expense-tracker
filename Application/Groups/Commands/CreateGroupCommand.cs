using Application.Shared.Command;

namespace Application.Groups;

public sealed record CreateGroupCommand(Guid GroupId, string GroupName, Guid UserId) : ICommand;
