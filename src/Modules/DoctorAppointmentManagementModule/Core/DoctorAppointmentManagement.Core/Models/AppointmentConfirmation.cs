using DoctorAppointmentManagement.Core.Domain.Enums;

namespace DoctorAppointmentManagement.Core.Models
{
	public class AppointmentConfirmation
	{
		public Guid Id { get; set; }
		public int SlotId { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }
		public AppointmentStatus AppointmentStatus { get; set; }
		public DateTime ReservedAt { get; set; }
	}
}
