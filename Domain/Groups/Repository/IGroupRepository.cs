using Domain.Shared.Base;

namespace Domain.Groups;

public interface IGroupRepository : IRepository<Group>
{
    public Task Delete(Group group);
}
