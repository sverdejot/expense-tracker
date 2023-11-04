using Domain.Shared.Base;
using MediatR;

namespace Application.Shared;

public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}
