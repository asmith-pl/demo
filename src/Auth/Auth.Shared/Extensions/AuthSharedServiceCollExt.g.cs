using Microsoft.Extensions.DependencyInjection;
using PeakLogix.App1.Common.Shared.ApiClients;
using PeakLogix.App1.Common.Shared.Contracts;
using PeakLogix.App1.Auth.Shared.ApiClients;
using PeakLogix.App1.Auth.Shared.Contracts;
using sv1 = PeakLogix.App1.Auth.Shared.ApiClients.v1;
using cv1 = PeakLogix.App1.Auth.Shared.Contracts.v1;

namespace PeakLogix.App1.Auth.Shared.Extensions;

public static partial class AuthSharedServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		services.AddHttpClient<ISystemService, AuthSystemApiClient>();
		
		// TenantService
		services.AddHttpClient<cv1.ITenantService, sv1.TenantApiClient>();
	}
}
