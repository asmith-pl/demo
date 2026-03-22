using Microsoft.Extensions.DependencyInjection;
using PeakLogix.App1.Common.Shared.ApiClients;
using PeakLogix.App1.Common.Shared.Contracts;
using PeakLogix.App1.App.Shared.ApiClients;
using PeakLogix.App1.App.Shared.Contracts;
using sv1 = PeakLogix.App1.App.Shared.ApiClients.v1;
using cv1 = PeakLogix.App1.App.Shared.Contracts.v1;

namespace PeakLogix.App1.App.Shared.Extensions;

public static partial class AppSharedServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		services.AddHttpClient<ISystemService, AppSystemApiClient>();
		
		// ClientService
		services.AddHttpClient<cv1.IClientService, sv1.ClientApiClient>();
	}
}
