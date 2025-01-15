using DoctorAppointmentManagement.Core.Models;

namespace DoctorAppointmentManagement.Core.InPutPorts.Services;

public interface IAppointmentServices
{
	Task<List<Appointment>> GetUpcomingAppointments();
	Task<AppointmentConfirmation> CompleteUpcomingAppointment(Appointment appointment);
	Task<AppointmentConfirmation> CancelUpcomingAppointment(Appointment appointment);

}