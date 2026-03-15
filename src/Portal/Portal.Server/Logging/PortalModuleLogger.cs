using LogixPro.LogixPro.Portal.Server;
using PeakLogix.LogixPro.Common.Api.Logging;

namespace PeakLogix.LogixPro.Portal.Server.Logging
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
