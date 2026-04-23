using PeakLogix.PickPro.Common.Shared.Contracts;
using PeakLogix.PickPro.Common.Shared.DTOs;
using PeakLogix.PickPro.Integration.Services;
using System.Security.Claims;

namespace PeakLogix.PickPro.Integration.Api.Endpoints;

public static class IntegrationSystemEndpoints
{
	public static IEndpointRouteBuilder MapIntegrationSystemEndpoints(this IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("api/integration/system")
			.WithTags("Import");

		group.MapGet("ping", Ping)
			.Produces<PingResult>(StatusCodes.Status200OK)
			.AllowAnonymous();

		group.MapGet("health", Health)
			.Produces<object>(StatusCodes.Status200OK);

		group.MapPost("getserviceinfo", GetServiceInfo)
			.Produces<object>(StatusCodes.Status200OK)
			.AllowAnonymous();

		return app;
	}

	private static IResult Ping(ClaimsPrincipal user)
	{
		return Results.Ok(new PingResult(IntegrationConstants.ModuleId, "System"));
	}

	private static async Task<IResult> Health(ISystemService systemService)
	{
		var healthStatus = await systemService.Health();
		return Results.Ok(healthStatus);
	}

	private static async Task<IResult> GetServiceInfo(ISystemService systemService)
	{
		var serviceInfo = await systemService.GetServiceInfo();
		return Results.Ok(serviceInfo);
	}
}
