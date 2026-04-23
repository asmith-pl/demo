using PeakLogix.PickPro.App.Shared.Contracts.v1;
using PeakLogix.PickPro.Common.Shared.DTOs;
using PeakLogix.PickPro.Integration.Shared.Authorization;
using System.Security.Claims;

namespace PeakLogix.PickPro.Integration.Api.Endpoints.v1;

public static class ImportEndpoints
{
	public static IEndpointRouteBuilder MapImportEndpoints(this IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("api/integration/v1/import")
			.WithTags("Import")
			.RequireAuthorization(IntegrationPermissions.Read);

		group.MapGet("importmethod1", ImportMethod1)
			.Produces<Guid>(StatusCodes.Status200OK);

		group.MapGet("importmethod2", ImportMethod2)
			.Produces<Guid>(StatusCodes.Status200OK);

		group.MapGet("importmethod3", ImportMethod3)
			.Produces<Guid>(StatusCodes.Status200OK);

		return app;
	}

	public static async Task<Result<string>> ImportMethod1(IImportService importService, ClaimsPrincipal user)
	{
		var data = await importService.ImportMethod1();
		return Result<string>.Ok(data);
	}

	public static async Task<Result<string>> ImportMethod2(IImportService importService)
	{
		var data = await importService.ImportMethod2();
		return Result<string>.Ok(data);
	}

	public static async Task<Result<string>> ImportMethod3(IImportService importService)
	{
		var data = await importService.ImportMethod3();
		return Result<string>.Ok(data);
	}
}
