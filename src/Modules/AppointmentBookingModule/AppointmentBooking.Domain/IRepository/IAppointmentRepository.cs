using AppointmentBooking.Domain.DomainModels;

namespace AppointmentBooking.Domain.IRepository;

public interface IAppointmentRepository
{
	Task<Guid> CreateAppointment(Appointment appointment);
	Task<List<Appointment>> GetUpCommingAppointments();
	Task<Appointment> UpdateAppointment(Appointment appointment);


}