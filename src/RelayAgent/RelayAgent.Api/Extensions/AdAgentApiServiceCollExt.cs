using PeakLogix.PickPro.Common.Api.Extensions;
using PeakLogix.PickPro.RelayAgent.Services;
using Scalar.AspNetCore;

namespace PeakLogix.PickPro.RelayAgent.Api.Extensions;

public static partial class RelayAgentApiServiceCollExt
{
	public static IServiceCollection AddRelayAgentApiServices(this IServiceCollection services)
	{
		// Add system-level services
		services.AddCurrentUserServices();
		services.AddOpenApi();
		services.AddHealthChecks()
			.AddCheck<HealthService>("AD Agent Service Health");

		// TODO: Register services here

		return services;
	}

	/// <summary> 
	/// Maps endpoints
	/// </summary>
	public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
	{
		// TODO: Add endpoint mappings here
		return app;
	}

	/// <summary> 
	/// Maps OpenAPI and Scalar API documentation endpoints for Auth API.
	/// Call this in development or when you want to expose API documentation.
	/// </summary>
	public static IEndpointRouteBuilder MapRelayAgentApiDocumentation(this IEndpointRouteBuilder app)
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
