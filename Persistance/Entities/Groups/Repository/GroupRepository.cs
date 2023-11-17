using Domain.Groups;
using Persistance.Shared;

namespace Persistance;

internal class GroupRepository : AbstractRepository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task Delete(Group group)
    {
        _context.Set<Group>().Remove(group);
        return Task.CompletedTask;
    }
}
