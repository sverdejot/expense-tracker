using Application;
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

        config.NewConfig<(Guid id, JoinGroupRequest request), JoinGroupCommand>()
            .Map(command => command.GroupId, request => request.id)
            .Map(command => command.NewMember, request => request.request.Member);
    }
}
