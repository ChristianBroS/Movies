using Application.Abstractions.Behaviors;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddExceptionHandler<CustomExceptionHandler>();

        //services.AddScoped<IUser, CurrentUser>();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddScoped(
            typeof(LoggingPipelineBehavior<,>));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();

        return services;
    }
}