using PeakLogix.LogixPro.AdAgent.Api;
using PeakLogix.LogixPro.Common.Shared.Contracts;
using PeakLogix.LogixPro.Common.Shared.DTOs;
using Microsoft.Extensions.Logging;

namespace PeakLogix.LogixPro.App.Api.Services;

public class AdAgentSystemService : ISystemService
{
    private readonly ILogger<AdAgentSystemService> _logger;

    public AdAgentSystemService(ILogger<AdAgentSystemService> logger)
    {
        _logger = logger;
    }

    public Task<HealthStatus> Health()
    {
        return Task.FromResult(new HealthStatus
        {
            Status = StatusLevel.Ok,
            Message = $"{AdAgentConstants.ModuleId} module is healthy",
            Timestamp = DateTime.UtcNow
        });
    }

    public Task<ServiceInfo> GetServiceInfo()
    {
        var info = new ServiceInfo
        {
            ServiceName = AdAgentConstants.ModuleId,
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
            Version = typeof(AdAgentSystemService).Assembly.GetName().Version?.ToString() ?? "0.0.0",
            HostName = Environment.MachineName,
            Status = StatusLevel.Ok,
            StartTimeUtc = DateTime.UtcNow.AddHours(-1), // Example start time
            Uptime = TimeSpan.FromHours(1) // Example uptime
        };
        return Task.FromResult(info);
    }
}

