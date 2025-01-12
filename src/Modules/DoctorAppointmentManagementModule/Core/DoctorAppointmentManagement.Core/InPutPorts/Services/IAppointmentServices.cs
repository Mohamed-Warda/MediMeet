using DoctorAppointmentManagement.Core.Models;

namespace DoctorAppointmentManagement.Core.InPutPorts.Services;

public interface IAppointmentServices
{
    Task<List<Appointment>> GetUpcomingAppointments();
}