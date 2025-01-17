﻿using DoctorAppointmentManagement.AdapterInfra.Entities;
using DoctorAppointmentManagement.Core.Models;

namespace DoctorAppointmentManagement.AdapterInfra.Extension
{
	public static class Extensions
	{
		public static AppointmentConfirmationEntity ToEntity(this AppointmentConfirmation appointment)
		{
			return new AppointmentConfirmationEntity
			{
				Id = appointment.Id,
				SlotId = appointment.SlotId,
				PatientId = appointment.PatientId,
				PatientName = appointment.PatientName,
				ReservedAt = appointment.ReservedAt,
				AppointmentStatus = (int)appointment.AppointmentStatus,
			};
		}

		public static AppointmentConfirmation ToModel(this AppointmentConfirmationEntity appointment)
		{
			return new AppointmentConfirmation
			{
				Id = appointment.Id,
				SlotId = appointment.SlotId,
				PatientId = appointment.PatientId,
				PatientName = appointment.PatientName,
				ReservedAt = appointment.ReservedAt,
				AppointmentStatus = (Core.Domain.Enums.AppointmentStatus)appointment.AppointmentStatus,

			};
		}
	}
}