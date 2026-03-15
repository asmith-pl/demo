using LogixPro.LogixPro.Portal.Server;
using LogixPro.LogixPro.Portal.Server.Interfaces;
using PeakLogix.LogixPro.Common.Shared.DTOs;
using PeakLogix.LogixPro.Portal.Server.DTOs;
using PeakLogix.LogixPro.Portal.Server.Logging;

namespace PeakLogix.LogixPro.Portal.Server.Services;

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
