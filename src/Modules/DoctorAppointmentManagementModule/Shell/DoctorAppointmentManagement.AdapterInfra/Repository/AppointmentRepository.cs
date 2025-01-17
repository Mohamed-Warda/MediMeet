using AppointmentBooking.Shared.Contracts;
using DoctorAppointmentManagement.AdapterInfra.Database;
using DoctorAppointmentManagement.AdapterInfra.Extension;
using DoctorAppointmentManagement.Core.Domain.Enums;
using DoctorAppointmentManagement.Core.Models;
using DoctorAppointmentManagement.Core.OutputPorts.IRepository;

namespace DoctorAppointmentManagement.AdapterInfra.Repository
{
	public class AppointmentRepository : IAppointmentRepository
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
			return models;
		}

		public async Task<AppointmentConfirmation> CompleteUpComingAppointment(Appointment appointment)
		{
			if (appointment == null)
				throw new ArgumentNullException(nameof(appointment));

			var AppointmentConfirmation = new AppointmentConfirmation
			{
				Id = appointment.Id,
				SlotId = appointment.SlotId,
				PatientId = appointment.PatientId,
				PatientName = appointment.PatientName,
				AppointmentStatus = AppointmentStatus.Confirmed,
				ReservedAt = appointment.ReservedAt
			};
			var entity = AppointmentConfirmation.ToEntity();
			InMemoryDb.AppointmentConfirmation.Add(entity);
			return entity.ToModel();

		}

		public async Task<AppointmentConfirmation> CancelUpComingAppointment(Appointment appointment)
		{
			if (appointment == null)
				throw new ArgumentNullException(nameof(appointment));

			var AppointmentConfirmation = new AppointmentConfirmation
			{
				Id = appointment.Id,
				SlotId = appointment.SlotId,
				PatientId = appointment.PatientId,
				PatientName = appointment.PatientName,
				AppointmentStatus = AppointmentStatus.Cancelled,
				ReservedAt = appointment.ReservedAt
			};
			var entity = AppointmentConfirmation.ToEntity();
			InMemoryDb.AppointmentConfirmation.Add(entity);
			return entity.ToModel();
		}
	}
}
