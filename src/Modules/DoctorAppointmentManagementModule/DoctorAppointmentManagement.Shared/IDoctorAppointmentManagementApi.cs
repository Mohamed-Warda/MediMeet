using AppointmentBooking.Infrastructure.Entities;

namespace DoctorAppointmentManagement.Shared
{
	public interface IDoctorAppointmentManagementApi
	{
		List<AppointmentEntity> AppointmentList();
	}
}
