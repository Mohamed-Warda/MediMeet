using DoctorAvailability.DataAccess.Entities;

namespace DoctorAvailability.DataAccess.Database;


public static class InMemoryDb
{
    public static List<Doctor> Doctors = new()
    {
        new Doctor()
        {
            Id = 1,
            Name = "Dr. Mohamed Warda"
        }
    };
       
    public static List<Slot> Slots = new()
    {
        new Slot()
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Parse("2025-01-22T09:00:00"),
            DoctorId = 1,
            DoctorName = "Dr. Mohamed Warda",
            IsReserved = false,
            Cost = 50.0m
        },
        new Slot()
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Parse("2025-01-22T10:00:00"),
            DoctorId = 1,
            DoctorName = "Dr. Mohamed Warda",
            IsReserved = false,
            Cost = 50.0m
        },
        new Slot()
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Parse("2025-01-22T11:00:00"),
            DoctorId = 1,
            DoctorName = "Dr. Mohamed Warda",
            IsReserved = true,
            Cost = 50.0m
        },
        new Slot()
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Parse("2025-01-22T12:00:00"),
            DoctorId = 1,
            DoctorName = "Dr. Mohamed Warda",
            IsReserved = false,
            Cost = 60.0m
        }
    };
}