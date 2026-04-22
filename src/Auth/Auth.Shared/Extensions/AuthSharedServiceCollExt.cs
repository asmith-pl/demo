using PeakLogix.PickPro.Auth.Shared.ApiClients;
using PeakLogix.PickPro.Auth.Shared.ApiClients.v1;
using PeakLogix.PickPro.Auth.Shared.Contracts.v1;
using PeakLogix.PickPro.Common.Shared.Config;
using PeakLogix.PickPro.Common.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.PickPro.Auth.Shared.Extensions;

public static partial class AuthSharedServiceCollExt
{
    // Declaration of partial method for code-generated services
    static partial void AddGeneratedServices(IServiceCollection services);

    public static IServiceCollection AddAuthSharedServices(this IServiceCollection services, ApiClientConfig apiClientConfig, bool inProcess)
    {
        if (!inProcess)
        {
            string? baseUrl = apiClientConfig.BaseUrl;
            if (string.IsNullOrEmpty(apiClientConfig.BaseUrl))
            {
                throw new InvalidOperationException(
                    "BaseUrl is missing from Auth configuration. It is required when InProcess is false");
            }

            services.AddHttpClient<ISystemService, AuthSystemApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpContextAccessor();
            services.AddTransient<TenantApiBearerTokenHandler>();

            // Add code-generated services
            AddGeneratedServices(services);

            services.AddHttpClient<ITenantService, TenantApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            })
            .AddHttpMessageHandler<TenantApiBearerTokenHandler>();
        }

        return services;
    }
}
