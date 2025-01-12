﻿namespace DoctorAppointmentManagement.Core.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public int SlotId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime ReservedAt { get; set; }
    
}