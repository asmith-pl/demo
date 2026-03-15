using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using PeakLogix.LogixPro.Common.Api.Filters;
using sv1 = PeakLogix.LogixPro.Auth.Api.Services.v1;
using cv1 = PeakLogix.LogixPro.Auth.Shared.Contracts.v1;
using PeakLogix.LogixPro.Auth.Endpoints.v1;

namespace PeakLogix.LogixPro.Auth.Api.Extensions;

public static partial class AuthApiServiceCollExt
{
	public static partial void AddGeneratedServices(IServiceCollection services)
	{
		// TenantService
		services.AddScoped<cv1.ITenantService, sv1.TenantService>();
		services.AddScoped<ApiExceptionFilter<sv1.TenantService>>();

		// UserService
		services.AddScoped<cv1.IUserService, sv1.UserService>();
		services.AddScoped<ApiExceptionFilter<sv1.UserService>>();

		// UserClaimService
		services.AddScoped<cv1.IUserClaimService, sv1.UserClaimService>();
		services.AddScoped<ApiExceptionFilter<sv1.UserClaimService>>();

		// RoleService
		services.AddScoped<cv1.IRoleService, sv1.RoleService>();
		services.AddScoped<ApiExceptionFilter<sv1.RoleService>>();

		// RoleClaimService
		services.AddScoped<cv1.IRoleClaimService, sv1.RoleClaimService>();
		services.AddScoped<ApiExceptionFilter<sv1.RoleClaimService>>();

		// AppRegistrationService
		services.AddScoped<cv1.IAppRegistrationService, sv1.AppRegistrationService>();
		services.AddScoped<ApiExceptionFilter<sv1.AppRegistrationService>>();

		// ScopeService
		services.AddScoped<cv1.IScopeService, sv1.ScopeService>();
		services.AddScoped<ApiExceptionFilter<sv1.ScopeService>>();
	}

	public static partial void MapGeneratedEndpoints(IEndpointRouteBuilder app)
	{
		app.MapTenantEndpoints();
		app.MapUserEndpoints();
		app.MapUserClaimEndpoints();
		app.MapRoleEndpoints();
		app.MapRoleClaimEndpoints();
		app.MapAppRegistrationEndpoints();
		app.MapScopeEndpoints();
	}
}
