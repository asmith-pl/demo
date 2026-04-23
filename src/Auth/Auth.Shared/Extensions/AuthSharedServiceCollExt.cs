using Microsoft.Extensions.DependencyInjection;
using PeakLogix.PickPro.Auth.Shared.ApiClients;
using PeakLogix.PickPro.Auth.Shared.ApiClients.v1;
using PeakLogix.PickPro.Auth.Shared.Contracts.v1;
using PeakLogix.PickPro.Common.Shared.Config;
using PeakLogix.PickPro.Common.Shared.Contracts;
using System.Runtime.Intrinsics.Arm;

namespace PeakLogix.PickPro.Auth.Shared.Extensions;

public static partial class AuthSharedServiceCollExt
{
	public static IServiceCollection AddAuthSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig)
	{
		if (string.IsNullOrEmpty(apiClientConfig.BaseUrl))
		{
			throw new InvalidOperationException(
				"BaseUrl is missing from Auth configuration. It is required when InProcess is false");
		}

		services.AddHttpContextAccessor();
		services.AddTransient<TenantApiBearerTokenHandler>();

		// TenantService
		services.AddHttpClient<ITenantService, TenantApiClient>(client =>
		{
			client.BaseAddress = new Uri(apiClientConfig.BaseUrl);
		})
		.AddHttpMessageHandler<TenantApiBearerTokenHandler>();

		return services;
	}
}
