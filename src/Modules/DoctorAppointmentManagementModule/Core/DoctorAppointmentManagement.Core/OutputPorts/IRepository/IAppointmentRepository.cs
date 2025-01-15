using DoctorAppointmentManagement.Core.Models;

namespace DoctorAppointmentManagement.Core.OutputPorts.IRepository;

public interface IAppointmentRepository
{
	Task<List<Appointment>> GetUpComingAppointments();

	Task<AppointmentConfirmation> CompleteUpComingAppointment(Appointment appointment);
	Task<AppointmentConfirmation> CancelUpComingAppointment(Appointment appointment);
}