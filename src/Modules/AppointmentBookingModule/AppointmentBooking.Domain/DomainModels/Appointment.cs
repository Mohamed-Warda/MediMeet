using System.ComponentModel;

namespace AppointmentBooking.Domain.DomainModels;

public class Appointment
{
  
    public Guid Id { get; set; }
    public int SlotId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public AppointmentStatus Status { get; set; }
    public DateTime ReservedAt { get; set; }
    
    
    //Add Validation and ctor
    //factory method is better than constructor as it show intention
    public static Appointment CreateAppointment( int slotId, int patientId, string patientName, string doctorName,DateTime reservedAt)
    {
        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            SlotId = slotId,
            PatientId = patientId,
            PatientName = patientName,
            DoctorName = doctorName,
            Status = AppointmentStatus.Pending,
            ReservedAt= reservedAt
        };

        return appointment;
    }
    public static Appointment CancelAppointment(Appointment appointment)
    {
        appointment.Status = AppointmentStatus.Cancelled;
        return appointment;
    }
    public static Appointment ConfirmAppointment(Appointment appointment)
    {
        appointment.Status = AppointmentStatus.Confirmed;
        return appointment;
    }
} 

public enum AppointmentStatus
{
    Pending,    
    Confirmed,
    Cancelled
}