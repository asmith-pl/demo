using Microsoft.Extensions.DependencyInjection;
using PeakLogix.LogixPro.Common.Shared.ApiClients;
using PeakLogix.LogixPro.Common.Shared.Contracts;
using PeakLogix.LogixPro.Auth.Shared.ApiClients;
using PeakLogix.LogixPro.Auth.Shared.Contracts;
using sv1 = PeakLogix.LogixPro.Auth.Shared.ApiClients.v1;
using cv1 = PeakLogix.LogixPro.Auth.Shared.Contracts.v1;

namespace PeakLogix.LogixPro.Auth.Shared.Extensions;

public static partial class AuthSharedServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		services.AddHttpClient<ISystemService, AuthSystemApiClient>();
		
		// TenantService
		services.AddHttpClient<cv1.ITenantService, sv1.TenantApiClient>();
	}
}
