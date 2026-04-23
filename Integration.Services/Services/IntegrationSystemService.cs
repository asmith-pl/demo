using Microsoft.Extensions.Logging;
using PeakLogix.PickPro.Common.Shared.Contracts;
using PeakLogix.PickPro.Common.Shared.DTOs;

namespace PeakLogix.PickPro.Integration.Services.Services;

public class IntegrationSystemService : ISystemService
{
	private readonly ILogger<IntegrationSystemService> _logger;

	public IntegrationSystemService(ILogger<IntegrationSystemService> logger)
	{
		_logger = logger;
	}

	public Task<HealthStatus> Health()
	{
		return Task.FromResult(new HealthStatus
		{
			Status = StatusLevel.Ok,
			Message = $"{IntegrationConstants.ModuleId} module is healthy",
			Timestamp = DateTime.UtcNow
		});
	}

	public Task<ServiceInfo> GetServiceInfo()
	{
		var info = new ServiceInfo
		{
			ServiceName = IntegrationConstants.ModuleId,
			Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
			Version = typeof(IntegrationSystemService).Assembly.GetName().Version?.ToString() ?? "0.0.0",
			HostName = Environment.MachineName,
			Status = StatusLevel.Ok,
			StartTimeUtc = DateTime.UtcNow.AddHours(-1),
			Uptime = TimeSpan.FromHours(1)
		};
		return Task.FromResult(info);
	}
}
