using PeakLogix.App1.Common.Shared.DTOs;

namespace PeakLogix.App1.Common.Shared.Contracts;

public interface ISystemService
{
    Task<HealthStatus> Health();
    Task<ServiceInfo> GetServiceInfo();
}
