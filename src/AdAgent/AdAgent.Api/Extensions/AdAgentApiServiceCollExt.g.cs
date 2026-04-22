using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using PeakLogix.PickPro.Common.Api.Filters;
using sv1 = PeakLogix.PickPro.AdAgent.Api.Services.v1;
using cv1 = PeakLogix.PickPro.AdAgent.Shared.Contracts.v1;
using PeakLogix.PickPro.AdAgent.Api.Endpoints;
using PeakLogix.PickPro.AdAgent.Api.Endpoints.v1;

namespace PeakLogix.PickPro.AdAgent.Api.Extensions;

public static partial class AdAgentApiServiceCollExt
{
	public static partial void AddGeneratedServices(IServiceCollection services)
	{
		// AdService
		services.AddScoped<cv1.IAdService, sv1.AdService>();
		services.AddScoped<ApiExceptionFilter<sv1.AdService>>();
	}

	public static partial void MapGeneratedEndpoints(IEndpointRouteBuilder app)
	{
		app.MapAdEndpoints();
		ServiceRuntime.Start();
	}
}
