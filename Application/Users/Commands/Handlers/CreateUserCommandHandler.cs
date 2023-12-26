using Application.Shared.Command;
using Domain;

namespace Application;

public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var id = UserId.Create(request.Id);
        var mail = UserMail.Create(request.Mail);

        var user = User.Create(id, mail);

        await _userRepository.Add(user);
    }
}
