using Aspire.Hosting;
using PeakLogix.LogixPro.App.Shared.ApiClients;
using PeakLogix.LogixPro.App.Shared.ApiClients.v1;
using PeakLogix.LogixPro.App.Shared.Contracts.v1;
using PeakLogix.LogixPro.Auth.Shared.ApiClients;
using PeakLogix.LogixPro.Common.Data;
using PeakLogix.LogixPro.Common.Data.Config;
using PeakLogix.LogixPro.Common.Shared.Config;
using PeakLogix.LogixPro.Common.Shared.Contracts;
using PeakLogix.LogixPro.Tests.Integration.Authorization;
using PeakLogix.LogixPro.Tests.Integration.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace PeakLogix.LogixPro.Tests.Integration.Fixtures;

public class GlobalTestFixture : IAsyncLifetime
{
    public DistributedApplication App { get; private set; } = default!;
    public ServiceProvider Services { get; private set; } = default!;
    public IConfiguration Configuration { get; private set; } = default!;

    public async ValueTask InitializeAsync()
    {
        // --- Configuration ---
        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        // --- Aspire distributed app ---
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Aspire_AppHost>();
        appHost.Services.AddLogging(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Debug);
            logging.AddFilter(appHost.Environment.ApplicationName, LogLevel.Debug);
            logging.AddFilter("Aspire.", LogLevel.Debug);
        });
        appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            clientBuilder.AddStandardResilienceHandler();
        });

        App = await appHost.BuildAsync();
        await App.StartAsync();

        var timeout = TimeSpan.FromSeconds(60);
        await App.ResourceNotifications
            .WaitForResourceHealthyAsync("portal-server")
            .WaitAsync(timeout);

        var services = new ServiceCollection();
        services.AddSingleton(Configuration);
        services.AddScoped<TestAuthContext>();

        // LogixProDb
        var dataConfig = DataConfigBuilder.Build(Configuration);
        services.AddDataServices(dataConfig);
        services.AddSingleton<IDataManager>(sp =>
        {
            var db = sp.GetRequiredService<LogixProDb>();
            return new DataManager(db);
        });

        // ApiClients
        var apiClientsConfig = ApiClientsConfigBuilder.Build(Configuration);
        services.AddSingleton(apiClientsConfig);
        if (apiClientsConfig.TryGetValue("App", out var appApiClientConfig))
        {
            services.AddScoped<ISystemService>(sp => new AppSystemApiClient(CreateAuthorizedClient(sp)));
            services.AddScoped<IPatientService>(sp => new PatientApiClient(CreateAuthorizedClient(sp)));
            services.AddScoped<IInvoiceService>(sp => new InvoiceApiClient(CreateAuthorizedClient(sp)));
        }
        if (apiClientsConfig.TryGetValue("Auth", out var authApiClientConfig))
        {
            services.AddScoped<ISystemService>(sp => new AuthSystemApiClient(CreateAuthorizedClient(sp)));
        }

        Services = services.BuildServiceProvider();

        // Initialize test data
        var dataManager = Services.GetRequiredService<IDataManager>();
        await dataManager.Initialize();
    }

    public async ValueTask DisposeAsync()
    {
        if (App != null)
            await App.DisposeAsync();
    }

    private HttpClient CreateAuthorizedClient(IServiceProvider serviceProvider)
    {
        var client = App.CreateHttpClient("portal-server");
        var token = serviceProvider.GetRequiredService<TestAuthContext>().CreateToken();

        if (!string.IsNullOrWhiteSpace(token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return client;
    }
}
