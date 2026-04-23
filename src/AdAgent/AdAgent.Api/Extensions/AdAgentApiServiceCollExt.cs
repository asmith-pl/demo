using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using PeakLogix.PickPro.AdAgent.Api.Config;
using PeakLogix.PickPro.Common.Api.Extensions;
using PeakLogix.PickPro.Common.Api.Filters;
using Scalar.AspNetCore;
using PeakLogix.PickPro.AdAgent.Api.Endpoints.v1;
using Sv1 = PeakLogix.PickPro.AdAgent.Api.Services.v1;
using Cv1 = PeakLogix.PickPro.AdAgent.Shared.Contracts.v1;

namespace PeakLogix.PickPro.AdAgent.Api.Extensions;

public static partial class AdAgentApiServiceCollExt
{
    /// <summary>
    /// Registers App API services.
    /// Call this when hosting App services (standalone or in-process).
    /// </summary>
    public static IServiceCollection AddAdAgentApiServices(this IServiceCollection services, AdAgentConfig adAgentConfig)
    {
        services.AddCurrentUserServices();

        // Register business logic services
        services.AddScoped<IConfigRepository, ConfigRepository>();
        services.AddSingleton(adAgentConfig);

        // Add code-generated services
		services.AddScoped<Cv1.IAdService, Sv1.AdService>();
		services.AddScoped<ApiExceptionFilter<Sv1.AdService>>();

        // Add OpenAPI support
        services.AddOpenApi();

        return services;
    }

    /// <summary> 
    /// Maps endpoints
    /// </summary>
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
		app.MapAdEndpoints();
        return app;
    }

    /// <summary> 
    /// Maps OpenAPI and Scalar API documentation endpoints for Auth API.
    /// Call this in development or when you want to expose API documentation.
    /// </summary>
    public static IEndpointRouteBuilder MapAdAgentApiDocumentation(this IEndpointRouteBuilder app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("Auth API")
                .WithTheme(ScalarTheme.DeepSpace);
        });

        return app;
    }


}
