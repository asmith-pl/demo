using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using PeakLogix.LogixPro.Common.Api.Filters;
using sv1 = PeakLogix.LogixPro.App.Api.Services.v1;
using cv1 = PeakLogix.LogixPro.App.Shared.Contracts.v1;
using PeakLogix.LogixPro.App.Endpoints.v1;

namespace PeakLogix.LogixPro.App.Api.Extensions;

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
