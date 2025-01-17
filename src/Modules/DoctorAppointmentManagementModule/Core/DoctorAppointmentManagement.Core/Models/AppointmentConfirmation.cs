using DoctorAppointmentManagement.Core.Domain.Enums;

namespace DoctorAppointmentManagement.Core.Models
{
	// we need to create a model that will store the appointment confirmation/Cancel details
	public class AppointmentConfirmation
	{
		public Guid Id { get; set; }
		public Guid SlotId { get; set; }
		public int PatientId { get; set; }
		public string PatientName { get; set; }
		public AppointmentStatus AppointmentStatus { get; set; }
		public Guid CanceledBy { get; set; }
		public Guid ConfirmedBy { get; set; }
		public string? Comments { get; set; }
		public DateTime ReservedAt { get; set; }
	}
}
