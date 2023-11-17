using Application;
using Mapster;

namespace WebAPI;

public class UsersMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<string, LoginCommand>()
            .Map(command => command, request => request);

        config.NewConfig<(Guid id, CreateUserRequest request), CreateUserCommand>()
            .Map(command => command.Id, request => request.id)
            .Map(command => command.Mail, request => request.request.Mail);
    }
}
