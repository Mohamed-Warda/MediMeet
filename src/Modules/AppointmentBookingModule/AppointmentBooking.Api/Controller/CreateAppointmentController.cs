using AppointmentBooking.Application.CreateAppointment;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBooking.Api.Controller;
[ApiController]
[Route("api/v1/[controller]")]
public class CreateAppointmentController: ControllerBase
{
    private readonly CreateAppointmentHandler _createAppointmentHandler;

    public CreateAppointmentController(CreateAppointmentHandler createAppointmentHandler)
    {
        _createAppointmentHandler = createAppointmentHandler;
    }
    [HttpPost("create")]
    public async Task<Guid> Create([FromBody]CreateAppointmentRequest request)
    {
        return await _createAppointmentHandler.CreateAppointment(request);
    }
}