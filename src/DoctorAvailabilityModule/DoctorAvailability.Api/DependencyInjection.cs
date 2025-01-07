using DoctorAvailability.Business.Services;
using DoctorAvailability.DataAccess.IRepository;
using DoctorAvailability.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAvailability.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDAModule(this IServiceCollection services)
    {
        services.AddScoped<ISlotRepository, SlotRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<SlotServices>();
        return services;
    }

}