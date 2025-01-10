using AppointmentBooking.Domain.DomainModels;
using AppointmentBooking.Domain.IRepository;

namespace AppointmentBooking.Application.CreateAppointment;

public class CreateAppointmentHandler
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateAppointmentHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
   
    public Guid CreateAppointment(CreateAppointmentRequest request)
    {
        var appointment = Appointment.CreateAppointment(request.SlotId,request.PatientId,request.PatientName,request.DoctorName,request.ReservedAt);
        
        return _appointmentRepository.CreateAppointment(appointment);
    }
    
}