using PeakLogix.LogixPro.App.Shared.ApiClients;
using PeakLogix.LogixPro.Common.Shared.Config;
using PeakLogix.LogixPro.Common.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.LogixPro.App.Shared.Extensions;

public static partial class AppSharedServiceCollExt
{
    // Declaration of partial method for code-generated services
    static partial void AddGeneratedServices(IServiceCollection services);

    public static IServiceCollection AddAppSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig, bool inProcess)
    {
        if (!inProcess)
        {
            string? baseUrl = apiClientConfig.BaseUrl;
            if (string.IsNullOrEmpty(apiClientConfig.BaseUrl))
            {
                throw new InvalidOperationException(
                    "BaseUrl is missing from Auth configuration. It is required when InProcess is false");
            }

            services.AddHttpClient<ISystemService, AppSystemApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            // Add code-generated services
            AddGeneratedServices(services);
        }

        return services;
    }
}
