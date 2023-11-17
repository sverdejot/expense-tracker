using Application.Groups;
using Mapster;
using WebAPI.Groups;

namespace WebAPI;

public class GroupsMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid id, CreateGroupRequest request), CreateGroupCommand>()
            .Map(command => command.GroupId, request => request.id)
            .Map(command => command.GroupName, request => request.request.Name);
    }
}
