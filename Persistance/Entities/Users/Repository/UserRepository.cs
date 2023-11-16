using Domain;
using Domain.Shared.Base;
using Persistance.Shared;

namespace Persistance;

internal class UserRepository : AbstractRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
