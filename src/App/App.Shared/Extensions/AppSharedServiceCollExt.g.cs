using Microsoft.Extensions.DependencyInjection;
using PeakLogix.LogixPro.Common.Shared.ApiClients;
using PeakLogix.LogixPro.Common.Shared.Contracts;
using PeakLogix.LogixPro.App.Shared.ApiClients;
using PeakLogix.LogixPro.App.Shared.Contracts;
using sv1 = PeakLogix.LogixPro.App.Shared.ApiClients.v1;
using cv1 = PeakLogix.LogixPro.App.Shared.Contracts.v1;

namespace PeakLogix.LogixPro.App.Shared.Extensions;

public static partial class AppSharedServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		services.AddHttpClient<ISystemService, AppSystemApiClient>();
		
		// ClientService
		services.AddHttpClient<cv1.IClientService, sv1.ClientApiClient>();
	}
}
