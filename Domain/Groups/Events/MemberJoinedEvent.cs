using Domain.Shared.Base;

namespace Domain.Groups;

public sealed class MemberJoinedEvent(Guid MemberId, Guid GroupId) : IDomainEvent;
