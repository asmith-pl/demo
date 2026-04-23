using PeakLogix.PickPro.App.Shared.Contracts.v1;
using PeakLogix.PickPro.Common.Api.Extensions;
using PeakLogix.PickPro.Common.Shared.Contracts;
using PeakLogix.PickPro.Integration.Api.Endpoints;
using PeakLogix.PickPro.Integration.Api.Endpoints.v1;
using PeakLogix.PickPro.Integration.Services.Services;
using PeakLogix.PickPro.Integration.Services.Services.v1;
using Scalar.AspNetCore;

namespace PeakLogix.PickPro.Integration.Api.Extensions;

public static partial class IntegrationApiServiceCollExt
{
	public static IServiceCollection AddIntegrationApiServices(this IServiceCollection services)
	{
		// Add system-level services
		services.AddCurrentUserServices();
		services.AddHealthChecks()
			.AddCheck<HealthService>("Integration API Health");

		// Register business logic services
		services.AddScoped<IImportService, ImportService>();

		// Add OpenAPI support
		services.AddOpenApi();

		return services;
	}

	/// <summary>
	/// Maps endpoints
	/// </summary>
	public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapImportEndpoints();

		return app;
	}

	/// <summary>
	/// Maps OpenAPI and Scalar API documentation endpoints for Integration API.
	/// Call this in development or when you want to expose API documentation.
	/// </summary>
	public static IEndpointRouteBuilder MapIntegrationApiDocumentation(this IEndpointRouteBuilder app)
	{
		app.MapOpenApi();
		app.MapScalarApiReference(options =>
		{
			options
				.WithTitle("Integration API")
				.WithTheme(ScalarTheme.DeepSpace);
		});

		return app;
	}
}
