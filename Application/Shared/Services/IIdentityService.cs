using Domain;

namespace Application;

public interface IIdentityService
{
    public Task<string> GenerateToken(User user);
}
