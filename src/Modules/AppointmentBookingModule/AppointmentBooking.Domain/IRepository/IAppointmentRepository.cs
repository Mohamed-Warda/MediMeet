using AppointmentBooking.Domain.DomainModels;

namespace AppointmentBooking.Domain.IRepository;

public interface IAppointmentRepository
{
    Guid CreateAppointment(Appointment appointment);

}