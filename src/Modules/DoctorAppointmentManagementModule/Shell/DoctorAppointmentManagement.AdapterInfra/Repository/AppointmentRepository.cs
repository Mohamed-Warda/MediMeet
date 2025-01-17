using AppointmentBooking.Shared.Contracts;
using DoctorAppointmentManagement.AdapterInfra.Database;
using DoctorAppointmentManagement.AdapterInfra.Extension;
using DoctorAppointmentManagement.Core.Domain.Enums;
using DoctorAppointmentManagement.Core.Models;
using DoctorAppointmentManagement.Core.OutputPorts.IRepository;
using DoctorAppointmentManagement.Shared.IntegrationEvents;
using MediatR;

namespace DoctorAppointmentManagement.AdapterInfra.Repository
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly IAppointmentBookingApi _appointmentBookingApi;
		private readonly IMediator _mediator;

		public AppointmentRepository(IAppointmentBookingApi appointmentBookingApi,IMediator mediator)
		{
			_appointmentBookingApi = appointmentBookingApi;
			_mediator = mediator;
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
			//update appoint cofirmetion
			var entity = AppointmentConfirmation.ToEntity();
			InMemoryDb.AppointmentConfirmation.Add(entity);
			await _mediator.Publish(new  AppointmentConfirmedEvent(appointment.Id));
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
			//delete the appintment from other module 
			// delete slot  
			var entity = AppointmentConfirmation.ToEntity();
			InMemoryDb.AppointmentConfirmation.Add(entity);
			 await _mediator.Publish(new  AppointmentCanceledEvent(appointment.Id,appointment.SlotId));
			return entity.ToModel();
		}
	}
}
