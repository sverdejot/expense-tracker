using Domain.Shared.Base;

namespace Domain;

public sealed record UserCreatedEvent(Guid id, string Mail) : IDomainEvent;
