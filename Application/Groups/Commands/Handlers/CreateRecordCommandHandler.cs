using Application.Shared.Command;
using Domain;
using Domain.Groups;

namespace Application;

public class CreateRecordCommandHandler(IGroupRepository groupRepository) : ICommandHandler<CreateRecordCommand>
{
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task Handle(CreateRecordCommand request, CancellationToken cancellationToken = default)
    {
        var criteria = new GroupByIdCriteria(GroupId.Create(request.Group));

        var group = await _groupRepository.MatchFirst(criteria);

        var memberPercentages = request.Percentages
            .Select(percentageMap => 
                RecordPercentage.Create(
                    UserId.Create(percentageMap.Key), 
                    percentageMap.Value))
            .ToList();

        var creator = UserId.Create(request.Creator);
        var id = GroupRecordId.Create(request.Id);

        var record = GroupRecord.Create(id, request.TotalAmount, creator, memberPercentages);

        group.AddRecord(record);
    }
}
