using PeakLogix.PickPro.Portal.Server.DTOs;

namespace PickPro.PickPro.Portal.Server.Interfaces;

public interface IPortalSystemService
{
	Task<PortalHealthStatus> Health();
}
