﻿using AppointmentBooking.Domain.DomainModels;

namespace AppointmentBooking.Infrastructure.Entities;

public class AppointmentEntity
{
    public Guid Id { get; set; }
    public Guid SlotId { get; set; }
    public int PatientId { get; set; }
    public AppointmentStatus Status { get; set; }
    public string PatientName { get; set; }
    public DateTime ReservedAt { get; set; }
}