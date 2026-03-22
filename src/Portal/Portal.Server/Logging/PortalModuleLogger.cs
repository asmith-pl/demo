using App1.App1.Portal.Server;
using PeakLogix.App1.Common.Api.Logging;

namespace PeakLogix.App1.Portal.Server.Logging
{
	public interface IPortalModuleLogger : IModuleLogger
	{
	}

	public class PortalModuleLogger : ModuleLoggerBase, IPortalModuleLogger
	{
		public PortalModuleLogger(ILoggerFactory loggerFactory) : base(loggerFactory, PortalConstants.ModuleId)
		{
		}
	}
}
