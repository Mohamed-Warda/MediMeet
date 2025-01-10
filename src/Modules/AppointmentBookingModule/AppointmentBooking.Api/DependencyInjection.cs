using AppointmentBooking.Application.CreateAppointment;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddABModule(this IServiceCollection services)
    {
        services.AddScoped<CreateAppointmentHandler>();
        return services;
    }
}