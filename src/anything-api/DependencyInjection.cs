using anything_api.Middlewares;
using Bugsnag.AspNet.Core;

namespace anything_api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment
    )
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        services.AddBugsnag(config =>
        {
            config.ApiKey = configuration["Integrations:Bugsnag:ApiKey"];
            config.ReleaseStage = environment.EnvironmentName;
        });

        return services;
    }
}