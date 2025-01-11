using AppointmentBooking.Domain.DomainModels;
using AppointmentBooking.Domain.IRepository;
using AppointmentBooking.Infrastructure.Database;
using AppointmentBooking.Infrastructure.Extentions;
using MediatR;

namespace AppointmentBooking.Infrastructure.Repository;

public class
    AppointmentRepository : IAppointmentRepository
{
    private readonly IMediator _mediator;

    public AppointmentRepository(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Guid> CreateAppointment(Appointment appointment)
    {
        var entity = appointment.ToEntity();
        InMemoryDb.Appointments.Add(entity);
        foreach (var domainEvent in appointment.DomainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
        return entity.Id;
    }
}