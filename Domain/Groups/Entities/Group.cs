using Domain.Shared.Base;

namespace Domain.Groups;

public class Group : AggregateRoot<Group>
{
    public GroupId Id { get; private set; }

    public GroupName Name { get; private set; }

    public UserId Admin { get; private set; }

    public HashSet<UserId> Members { get; private set; } = new();

    public List<GroupRecord> Records { get; private set; } = new();

    private Group()
    {
    }

    protected Group(GroupId id, GroupName name, UserId admin)
    {
        Id = id;
        Name = name;
        Admin = admin;
    }

    public static Group Create(GroupId id, GroupName name, UserId admin)
    {
        var group = new Group(id, name, admin);

        group.RecordEvent(new GroupCreatedEvent(id.Value, name.Value, admin.Value));

        return group;
    }

    public void Join(UserId user)
    {
        if (Members.Contains(user) is true || user == Admin)
            throw new AlreadyMemberException(user, this);

        Members.Add(user);
        RecordEvent(new MemberJoinedEvent(user.Value, Id.Value));
    }

    public void AddRecord(GroupRecord record)
    {
        Records.Add(record);
        RecordEvent(new RecordAddedEvent(
            Id.Value, 
            record.Amount, 
            record.Percentages.
                ToDictionary(
                    percentage => percentage.Member.Value, 
                    percentage => percentage.Percentage)));
    }
    
}
