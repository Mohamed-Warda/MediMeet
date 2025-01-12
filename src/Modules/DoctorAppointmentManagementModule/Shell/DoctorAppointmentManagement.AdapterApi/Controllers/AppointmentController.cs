using DoctorAppointmentManagement.Core.InPutPorts.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentManagement.AdapterApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AppointmentController:ControllerBase
{
    private readonly IAppointmentServices _appointmentServices;

    public AppointmentController(IAppointmentServices appointmentServices)
    {
        _appointmentServices = appointmentServices;
    }
    
    [HttpGet("GetUpcomingAppointments")]
    public async Task<IActionResult> GetUpcomingAppointments()
    {
        
        return Ok( await _appointmentServices.GetUpcomingAppointments());
    }
}