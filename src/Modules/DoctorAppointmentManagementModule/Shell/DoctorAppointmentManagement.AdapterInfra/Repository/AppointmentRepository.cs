using AppointmentBooking.Shared.Contracts;
using DoctorAppointmentManagement.Core.Models;
using DoctorAppointmentManagement.Core.OutputPorts.IRepository;

namespace DoctorAppointmentManagement.AdapterInfra.Repository
{
	public class AppointmentRepository:IAppointmentRepository
	{
		private readonly IAppointmentBookingApi _appointmentBookingApi;

		public AppointmentRepository(IAppointmentBookingApi appointmentBookingApi)
		{
			_appointmentBookingApi = appointmentBookingApi;
		}
		public async Task<List<Appointment>> GetUpComingAppointments()
		{
			var entity = await _appointmentBookingApi.GetUpComingAppointments();
			 var models = entity.Select(a => new Appointment()
			 {
				 Id = a.Id,
				 PatientId = a.PatientId,
				 PatientName = a.PatientName,
				 ReservedAt = a.ReservedAt,
				 SlotId = a.SlotId,
			 }).ToList();
			return  models;
		}
		
	}
}
