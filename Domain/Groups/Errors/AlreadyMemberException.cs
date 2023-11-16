using Domain.Shared.Base;

namespace Domain.Groups;

public class AlreadyMemberException : DomainException
{
    public AlreadyMemberException(UserId user, Group group) : base($"The user with ID [{user.Value}] is alread member of group [{group.Name.Value} | {group.Id.Value}]")
    {
    }
}
