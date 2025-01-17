namespace DoctorAppointmentManagement.AdapterInfra.Entities;

public class AppointmentConfirmationEntity
{
    public Guid Id { get; set; }
    public Guid SlotId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public int AppointmentStatus { get; set; }
    public string? CanceledBy { get; set; }
    public string? ConfirmedBy { get; set; }
    public string? Comments { get; set; }
    public DateTime ReservedAt { get; set; }
}