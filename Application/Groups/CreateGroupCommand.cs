using Application.Shared.Command;

namespace Application;

public sealed record CreateGroupCommand(Guid GroupId, string GroupName, Guid UserId) : ICommand;
