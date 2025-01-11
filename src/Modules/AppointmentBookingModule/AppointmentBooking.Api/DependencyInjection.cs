using AppointmentBooking.Application.CreateAppointment;
using AppointmentBooking.Application.EventHandlers;
using AppointmentBooking.Domain.DomainEvents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddABModule(this IServiceCollection services)
    {
        services.AddScoped<CreateAppointmentHandler>();
        services.AddMediatR(m=> m.RegisterServicesFromAssemblyContaining<CreateAppointmentHandler>()); 

        return services;
    }
}