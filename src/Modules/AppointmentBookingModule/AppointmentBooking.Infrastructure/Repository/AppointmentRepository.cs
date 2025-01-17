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


	public Task<List<Appointment>> GetUpComingAppointments()
	{
		var Appointment = InMemoryDb.Appointments.Where(x => x.Status == AppointmentStatus.Pending).ToList();
		var Models = Appointment.Select(x => x.ToModel()).ToList();
		return Task.FromResult(Models);


	}

	public bool ConfirmAppointment(Guid appointmentId)
	{
		var appointment = InMemoryDb.Appointments.FirstOrDefault(x => x.Id == appointmentId);
		if (appointment is null)
		{
			return false;
		}
		appointment.Status =AppointmentStatus.Confirmed;
		return true;
	}
	public bool CancelAppointment(Guid appointmentId)
	{
		var appointment = InMemoryDb.Appointments.FirstOrDefault(x => x.Id == appointmentId);
		if (appointment is null)
		{
			return false;
		}
		appointment.Status =AppointmentStatus.Cancelled;
		return true;
	}
}