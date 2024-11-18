using DailyDinner.Application.Interface.Authentication;
using DailyDinner.Infrastructure.Authentication;
using DailyDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DailyDinner.Infrastructure;

public static class DependencyInjection
{
        // builder.Services
        // .AddApplication()
        // .AddInfrastructure(builder.Configuration)
        // .AddControllers();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        return services;
    }
}