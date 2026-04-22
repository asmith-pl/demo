using Microsoft.Extensions.DependencyInjection;
using PeakLogix.PickPro.Common.Shared.ApiClients;
using PeakLogix.PickPro.Common.Shared.Contracts;
using PeakLogix.PickPro.App.Shared.ApiClients;
using PeakLogix.PickPro.App.Shared.Contracts;
using sv1 = PeakLogix.PickPro.App.Shared.ApiClients.v1;
using cv1 = PeakLogix.PickPro.App.Shared.Contracts.v1;

namespace PeakLogix.PickPro.App.Shared.Extensions;

public static partial class AppSharedServiceCollExt
{
	static partial void AddGeneratedServices(IServiceCollection services)
	{
		services.AddHttpClient<ISystemService, AppSystemApiClient>();
		
		// ClientService
		services.AddHttpClient<cv1.IClientService, sv1.ClientApiClient>();
	}
}
