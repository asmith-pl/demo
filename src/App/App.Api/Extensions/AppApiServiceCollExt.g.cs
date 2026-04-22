using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using PeakLogix.PickPro.Common.Api.Filters;
using sv1 = PeakLogix.PickPro.App.Api.Services.v1;
using cv1 = PeakLogix.PickPro.App.Shared.Contracts.v1;
using PeakLogix.PickPro.App.Endpoints.v1;

namespace PeakLogix.PickPro.App.Api.Extensions;

public static partial class AppApiServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		// ClientService
		services.AddScoped<cv1.IClientService, sv1.ClientService>();
		services.AddScoped<ApiExceptionFilter<sv1.ClientService>>();
	}

	static partial void MapGeneratedEndpoints(IEndpointRouteBuilder app)
	{
		app.MapClientEndpoints();
	}
}
