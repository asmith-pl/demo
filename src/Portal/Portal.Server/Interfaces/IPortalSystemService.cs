using PeakLogix.LogixPro.Portal.Server.DTOs;

namespace LogixPro.LogixPro.Portal.Server.Interfaces;

public interface IPortalSystemService
{
	Task<PortalHealthStatus> Health();
}
