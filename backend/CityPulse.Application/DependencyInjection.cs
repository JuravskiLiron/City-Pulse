using CityPulse.Application.Interfaces;
using CityPulse.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CityPulse.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        return services;
    }
}
