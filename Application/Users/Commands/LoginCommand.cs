using Application.Shared.Command;

namespace Application;

public sealed record LoginCommand(string Mail) : ICommand<string>;