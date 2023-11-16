using Domain.Shared.Base;

namespace Domain.Groups;

public sealed class GroupCreatedEvent(Guid GroupId, string GroupName, Guid AdminId) : IDomainEvent;
