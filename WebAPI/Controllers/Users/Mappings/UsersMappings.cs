using Application;
using Mapster;

namespace WebAPI;

public class UsersMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<string, LoginCommand>()
            .Map(command => command, request => request);
    }
}
