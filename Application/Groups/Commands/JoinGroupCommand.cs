using Application.Shared.Command;

namespace Application;

public sealed record JoinGroupCommand : ICommand
{
    public JoinGroupCommand(Guid newMember, Guid groupId)
    {
        NewMember = newMember;
        GroupId = groupId;
    }

    public Guid NewMember { get; set; }

    public Guid GroupId { get; set; }

    
}
