using DoctorAppointmentManagement.Core.Models;
using DoctorAppointmentManagement.Core.OutputPorts.IRepository;

namespace DoctorAppointmentManagement.Core.InPutPorts.Services;

public class AppointmentServices : IAppointmentServices
{
	private readonly IAppointmentRepository _appointmentRepository;

	public AppointmentServices(IAppointmentRepository appointmentRepository)
	{
		_appointmentRepository = appointmentRepository;
	}

	public async Task<List<Appointment>> GetUpcomingAppointments()
	{
		return await _appointmentRepository.GetUpComingAppointments();
	}
	public async Task<AppointmentConfirmation> CompleteUpcomingAppointment(Appointment appointment)
	{
		return await _appointmentRepository.CompleteUpComingAppointment(appointment);
	}
	public async Task<AppointmentConfirmation> CancelUpcomingAppointment(Appointment appointment)
	{
		return await _appointmentRepository.CancelUpComingAppointment(appointment);
	}


}