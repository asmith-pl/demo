using Microsoft.Extensions.DependencyInjection;
using PeakLogix.PickPro.Common.Shared.Config;

namespace PeakLogix.PickPro.RelayAgent.Shared.Extensions;

public static partial class RelayAgentSharedServiceCollExt
{
	// Declaration of partial method for code-generated services
	static partial void AddGeneratedServices(IServiceCollection services);

	public static IServiceCollection AddRelayAgentSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig, bool inProcess)
	{
		if (!inProcess)
		{
			string? baseUrl = apiClientConfig.BaseUrl;
			if (string.IsNullOrEmpty(apiClientConfig.BaseUrl))
			{
				throw new InvalidOperationException(
					"BaseUrl is missing from Auth configuration. It is required when InProcess is false");
			}

			// Add code-generated services
			AddGeneratedServices(services);
		}

		return services;
	}
}
