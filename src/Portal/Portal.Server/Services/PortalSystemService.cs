using PickPro.PickPro.Portal.Server;
using PickPro.PickPro.Portal.Server.Interfaces;
using PeakLogix.PickPro.Common.Shared.DTOs;
using PeakLogix.PickPro.Portal.Server.DTOs;
using PeakLogix.PickPro.Portal.Server.Logging;

namespace PeakLogix.PickPro.Portal.Server.Services;

public class PortalSystemService : IPortalSystemService
{
    private readonly IPortalModuleLogger _logger;

    public PortalSystemService(IPortalModuleLogger logger)
    {
        _logger = logger;
    }

    public Task<PortalHealthStatus> Health()
    {
        return Task.FromResult(new PortalHealthStatus
        {
            Status = StatusLevel.Ok,
            Message = $"{PortalConstants.ModuleId} module is healthy",
            Timestamp = DateTime.UtcNow
        });
    }
}
