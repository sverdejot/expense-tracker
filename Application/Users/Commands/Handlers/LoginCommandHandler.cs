using System.Reflection.Metadata;
using Application.Shared.Command;
using Domain;

namespace Application;

public sealed class LoginCommandHandler(
    IUserRepository userRepository,
    IIdentityService identityService) 
        : ICommandHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository = userRepository;

    private readonly IIdentityService _identityService = identityService;

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken = default)
    {
        var mail = UserMail.Create(request.Mail);
        var criteria = new UserByMailCriteria(mail);

        User? user = await _userRepository.MatchFirstOrDefault(criteria);

        if (user is null)
            throw new UserNotFoundException(mail);

        var token = await _identityService.GenerateToken(user);

        return token;
    }
}
