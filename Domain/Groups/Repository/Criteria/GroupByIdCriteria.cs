using System.Linq.Expressions;
using Domain.Shared.Base;

namespace Domain.Groups;

public class GroupByIdCriteria : Criteria<Group>
{
    public GroupByIdCriteria(GroupId groupId) : base(group => group.Id == groupId)
    {
    }
}
