using Shared.EventBus;

namespace AppointmentBooking.Domain.DomainEvents;

public record CreateAppointmentDomainEvent(string patientName, string doctorName, DateTime reservedAt) : IDomainEvent;
