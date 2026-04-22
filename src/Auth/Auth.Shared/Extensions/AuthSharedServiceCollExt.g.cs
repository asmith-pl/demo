using Microsoft.Extensions.DependencyInjection;
using PeakLogix.PickPro.Common.Shared.ApiClients;
using PeakLogix.PickPro.Common.Shared.Contracts;
using PeakLogix.PickPro.Auth.Shared.ApiClients;
using PeakLogix.PickPro.Auth.Shared.Contracts;
using sv1 = PeakLogix.PickPro.Auth.Shared.ApiClients.v1;
using cv1 = PeakLogix.PickPro.Auth.Shared.Contracts.v1;

namespace PeakLogix.PickPro.Auth.Shared.Extensions;

public static partial class AuthSharedServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		services.AddHttpClient<ISystemService, AuthSystemApiClient>();
		
		// TenantService
		services.AddHttpClient<cv1.ITenantService, sv1.TenantApiClient>();
	}
}
