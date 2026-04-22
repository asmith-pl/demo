using PeakLogix.PickPro.Common.Shared.DTOs;

namespace PeakLogix.PickPro.Common.Shared.Contracts;

public interface ISystemService
{
    Task<HealthStatus> Health();
    Task<ServiceInfo> GetServiceInfo();
}
