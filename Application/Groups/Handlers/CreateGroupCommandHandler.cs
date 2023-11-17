using Application.Shared.Command;
using Domain;
using Domain.Groups;

namespace Application.Groups;

public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public CreateGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken = default)
    {
        var name = GroupName.Create(request.GroupName);
        var id = GroupId.Create(request.GroupId);
        var admin = UserId.Create(request.UserId);

        var group = Group.Create(id, name, admin);

        await _groupRepository.Add(group);
    }
}
