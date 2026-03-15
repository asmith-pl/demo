using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PeakLogix.LogixPro.Auth.Data.Entities;
using PeakLogix.LogixPro.Auth.Api.Services.v1;
using PeakLogix.LogixPro.Common.Api.Extensions;
using PeakLogix.LogixPro.Common.Api.Filters;
using PeakLogix.LogixPro.Common.Shared.Requests;
using PeakLogix.LogixPro.Common.Shared.DTOs;
using PeakLogix.LogixPro.Auth.Shared.Contracts.v1;
using PeakLogix.LogixPro.Auth.Shared.DTOs;

namespace PeakLogix.LogixPro.Auth.Endpoints.v1;

public static class TenantEndpoints
{
	public static IEndpointRouteBuilder MapTenantEndpoints(this IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("api/auth/v1/tenant")
			.WithTags("Tenant");
	
		return app;
	}
}
