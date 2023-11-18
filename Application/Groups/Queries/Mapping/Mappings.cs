using Application.Groups;
using Domain;
using Domain.Groups;
using Mapster;

namespace Application;

public class Mappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RecordPercentage, PercentageDTO>()
            .Map(dto => dto.Percentage, vo => vo.Percentage)
            .Map(dto => dto.MemberId, vo => vo.Member.Value);
        
        config.NewConfig<GroupRecord, GroupRecordDTO>()
            .Map(dto => dto.Amount, record => record.Amount)
            .Map(dto => dto.Creator, record => record.Creator.Value)
            .Map(dto => dto.Percentages, record => record.Percentages.Adapt<PercentageDTO>());

        config.NewConfig<Group, GroupDTO>()
            .Map(dto => dto.Id, group => group.Id.Value)
            .Map(dto => dto.Name, group => group.Name.Value)
            .Map(dto => dto.Records, group => group.Records.Adapt<GroupRecordDTO>())
            .Map(dto => dto.Admin, group => group.Admin.Value)
            .Map(dto => dto.Members, group => group.Members.Select(member => member.Value).ToList());
    }
}
