using AppointmentBooking.Domain.DomainModels;
using AppointmentBooking.Domain.IRepository;
using AppointmentBooking.Infrastructure.Database;
using AppointmentBooking.Infrastructure.Extentions;

namespace AppointmentBooking.Infrastructure.Repository;

public class 
    AppointmentRepository: IAppointmentRepository
{

    public AppointmentRepository()
    {
    }
    
    public Guid CreateAppointment(Appointment appointment)
    { 
        var entity = appointment.ToEntity();
        InMemoryDb.Appointments.Add(entity);
        return entity.Id;
    }
}