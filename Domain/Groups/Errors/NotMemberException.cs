using Domain.Shared.Base;

namespace Domain.Groups;

public class NotMemberException : DomainException
{
    public NotMemberException(UserId user, Group group) : base($"The User with Id [{user.Value}] is not member of Group {group.Name} with Id [{group.Id}]")
    {
    }
}
