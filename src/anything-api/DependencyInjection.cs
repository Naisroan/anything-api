using anything_api.Middlewares;
using Bugsnag.AspNet.Core;

namespace anything_api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddBugsnag(config => config.ApiKey = configuration["Integrations:Bugsnag:ApiKey"]);
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return services;
    }
}