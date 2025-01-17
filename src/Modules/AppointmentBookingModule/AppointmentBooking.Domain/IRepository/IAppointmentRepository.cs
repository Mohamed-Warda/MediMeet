using AppointmentBooking.Domain.DomainModels;

namespace AppointmentBooking.Domain.IRepository;

public interface IAppointmentRepository
{
	Task<Guid> CreateAppointment(Appointment appointment);
	Task<List<Appointment>> GetUpComingAppointments();
	bool ConfirmAppointment(Guid appointmentId);
	bool CancelAppointment(Guid appointmentId);


}