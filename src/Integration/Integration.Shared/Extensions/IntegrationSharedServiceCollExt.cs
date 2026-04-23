using PeakLogix.PickPro.Common.Shared.Config;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.PickPro.Integration.Shared.Extensions;

public static partial class IntegrationSharedServiceCollExt
{
    public static IServiceCollection AddIntegrationSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig, bool inProcess)
    {
		// Add any shared services here

		return services;
    }
}
