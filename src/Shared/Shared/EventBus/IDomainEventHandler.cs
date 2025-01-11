using MediatR;

namespace Shared.EventBus;

public interface IDomainEventHandler<Event>:INotificationHandler<Event> where Event:IDomainEvent
{
    
}