using PickPro.PickPro.Portal.Server;
using PeakLogix.PickPro.Common.Api.Logging;

namespace PeakLogix.PickPro.Portal.Server.Logging
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
