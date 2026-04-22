using PeakLogix.PickPro.AdAgent.Shared.Contracts.v1;
using PeakLogix.PickPro.AdAgent.Shared.DTOs;
using PeakLogix.PickPro.AdAgent.Shared.Requests.v1;
using PeakLogix.PickPro.Common.Shared.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace PeakLogix.PickPro.AdAgent.Api.Endpoints.v1;

public static class AdEndpoints
{
	public static IEndpointRouteBuilder MapAdEndpoints(this IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("api/adagent/v1/ad")
			.WithTags("AdService");

		group.MapPost("AuthenticateUser", AuthenticateUser)
			.Produces<Guid>(StatusCodes.Status200OK);

		return app;
	}

	public static async Task<Result<AdAuthResult>> AuthenticateUser(IAdService adService, AuthenticateUserReq request)
	{
		var result = await adService.AuthenticateUser(request.UserUpnOrDomainUser, request.Password);
		return Result<AdAuthResult>.Ok(result);
	}

}
