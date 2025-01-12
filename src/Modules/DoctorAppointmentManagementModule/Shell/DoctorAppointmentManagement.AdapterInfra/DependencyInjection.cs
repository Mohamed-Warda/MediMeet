using DoctorAppointmentManagement.AdapterInfra.Repository;
using DoctorAppointmentManagement.Core.OutputPorts.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentManagement.AdapterInfra;

public static class DependencyInjection
{
    public static IServiceCollection AddDAMInfra(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        return services;
    }
}