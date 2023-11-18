using Application.Shared.Query;
using Domain.Groups;
using MapsterMapper;

namespace Application.Groups;

public class FindAllGroupsQueryHandler : IQueryHandler<FindAllGroupsQuery, List<GroupDTO>>
{
    private readonly IGroupRepository _groupRepository;

    private readonly IMapper _mapper;

    public FindAllGroupsQueryHandler(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<List<GroupDTO>> Handle(FindAllGroupsQuery request, CancellationToken cancellationToken = default)
    {
        var groups = await _groupRepository.All();

        return _mapper.Map<List<GroupDTO>>(groups);
    }
}
