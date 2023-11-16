using Domain.Shared.Base;

namespace Domain.Groups;

public class Group : AggregateRoot<Group>
{
    public GroupId Id { get; private set; }

    public GroupName Name { get; private set; }

    public UserId Admin { get; private set; }

    public HashSet<UserId> Members { get; private set; } = new();

    public List<GroupRecords> Records { get; private set; } = new();

    private Group()
    {
    }

    protected Group(GroupId id, GroupName name, UserId admin)
    {
    }

    public static Group Create(GroupId id, GroupName name, UserId admin)
    {
        var group = new Group(id, name, admin);

        group.RecordEvent(new GroupCreatedEvent(id.Value, name.Value, admin.Value));

        return group;
    }

    public void Join(UserId user)
    {
        if (Members.Contains(user) is true)
            throw new AlreadyMemberException(user, this);

        Members.Add(user);
        RecordEvent(new MemberJoinedEvent(user.Value, this.Id.Value));
    }
}
