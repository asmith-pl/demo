using PeakLogix.App1.AdAgent.Shared.ApiClients;
using PeakLogix.App1.Common.Shared.Config;
using PeakLogix.App1.Common.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.App1.AdAgent.Shared.Extensions;

public static partial class AdAgentSharedServiceCollExt
{
    // Declaration of partial method for code-generated services
    static partial void AddGeneratedServices(IServiceCollection services);

    public static IServiceCollection AddAdAgentSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig, bool inProcess)
    {
        if (!inProcess)
        {
            string? baseUrl = apiClientConfig.BaseUrl;
            if (string.IsNullOrEmpty(apiClientConfig.BaseUrl))
            {
                throw new InvalidOperationException(
                    "BaseUrl is missing from Auth configuration. It is required when InProcess is false");
            }

            services.AddHttpClient<ISystemService, AdAgentSystemApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            // Add code-generated services
            AddGeneratedServices(services);
        }

        return services;
    }
}
