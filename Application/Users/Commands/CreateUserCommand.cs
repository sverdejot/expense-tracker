
using Application.Shared.Command;

namespace Application;

public sealed record CreateUserCommand : ICommand
{
    public Guid Id { get; set; }

    public string Mail { get; set; }
}
