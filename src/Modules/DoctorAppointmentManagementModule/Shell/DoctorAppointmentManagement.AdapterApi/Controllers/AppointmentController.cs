using DoctorAppointmentManagement.Core.InPutPorts.Services;
using DoctorAppointmentManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;


namespace DoctorAppointmentManagement.AdapterApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AppointmentController : ControllerBase
{
	private readonly IAppointmentServices _appointmentServices;

	public AppointmentController(IAppointmentServices appointmentServices)
	{
		_appointmentServices = appointmentServices;
	}

	[HttpGet("GetUpcomingAppointments")]
	public async Task<IActionResult> GetUpcomingAppointments()
	{

		return Ok(await _appointmentServices.GetUpcomingAppointments());
	}

	[HttpPost("CompleteUpcomingAppointment")]
	public async Task<IActionResult> CompleteUpcomingAppointment(Appointment appointment)
	{
		return Ok(await _appointmentServices.CompleteUpcomingAppointment(appointment));
	}

	[HttpPost("CancelUpcomingAppointment")]
	public async Task<IActionResult> CancelUpcomingAppointment(Appointment appointment)
	{
		return Ok(await _appointmentServices.CancelUpcomingAppointment(appointment));
	}
}