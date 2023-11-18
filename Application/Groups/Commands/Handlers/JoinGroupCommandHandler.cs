using Application.Shared.Command;
using Domain;
using Domain.Groups;
using MediatR;

namespace Application;

public class JoinGroupCommandHandler : ICommandHandler<JoinGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public JoinGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Handle(JoinGroupCommand request, CancellationToken cancellationToken = default)
    {
        var groupId = GroupId.Create(request.GroupId);
        var memberId = UserId.Create(request.NewMember);

        var criteria = new GroupByIdCriteria(groupId);

        var group = await _groupRepository.MatchFirst(criteria);

        group.Join(memberId);
    }
}
