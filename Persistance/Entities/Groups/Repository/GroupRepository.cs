using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Persistance.Shared;

namespace Persistance;

internal class GroupRepository : AbstractRepository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Group>> All()
    {
        return await _context.Set<Group>().ToListAsync();
    }

    public Task Delete(Group group)
    {
        _context.Set<Group>().Remove(group);
        return Task.CompletedTask;
    }
}
