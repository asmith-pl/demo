using PeakLogix.LogixPro.Common.Shared.DTOs;

namespace PeakLogix.LogixPro.Common.Shared.Contracts;

public interface ISystemService
{
    Task<HealthStatus> Health();
    Task<ServiceInfo> GetServiceInfo();
}
