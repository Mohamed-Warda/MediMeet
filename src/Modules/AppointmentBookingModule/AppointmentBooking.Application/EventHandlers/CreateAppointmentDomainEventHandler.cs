using AppointmentBooking.Domain.DomainEvents;
using AppointmentConfirmation.Shared;
using Shared.EventBus;

namespace AppointmentBooking.Application.EventHandlers;

public class CreateAppointmentDomainEventHandler : IDomainEventHandler<CreateAppointmentDomainEvent>
{
    private readonly INotificationApi _notificationApi;

    public CreateAppointmentDomainEventHandler(INotificationApi notificationApi)
    {
        _notificationApi = notificationApi;
    }

    public Task Handle(CreateAppointmentDomainEvent notification, CancellationToken cancellationToken)
    {
        var message =
            $"Appointment created for {notification.patientName} on {notification.reservedAt} with Dr. {notification.doctorName}";
        var sendTo = new List<string>
        {
            notification.patientName, notification.doctorName
        };
        _notificationApi.SendNotification(sendTo, message);
        return Task.CompletedTask;
    }
}