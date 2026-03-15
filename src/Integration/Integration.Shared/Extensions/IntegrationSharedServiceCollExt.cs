using PeakLogix.LogixPro.Common.Shared.Config;
using PeakLogix.LogixPro.Common.Shared.Contracts;
using PeakLogix.LogixPro.Integration.Shared.ApiClients;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.LogixPro.Integration.Shared.Extensions;

public static partial class IntegrationSharedServiceCollExt
{
    // Declaration of partial method for code-generated services
    static partial void AddGeneratedServices(IServiceCollection services);

    public static IServiceCollection AddIntegrationSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig, bool inProcess)
    {
        if (!inProcess)
        {
            string? baseUrl = apiClientConfig.BaseUrl;
            if (string.IsNullOrEmpty(apiClientConfig.BaseUrl))
            {
                throw new InvalidOperationException(
                    "BaseUrl is missing from Integration configuration. It is required when InProcess is false");
            }

            services.AddHttpClient<ISystemService, IntegrationSystemApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            // Add code-generated services
            AddGeneratedServices(services);
        }

        return services;
    }
}
