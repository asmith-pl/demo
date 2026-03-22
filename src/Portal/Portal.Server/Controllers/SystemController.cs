using App1.App1.Portal.Server;
using App1.App1.Portal.Server.Interfaces;
using PeakLogix.App1.Common.Api.Filters;
using PeakLogix.App1.Common.Shared.DTOs;
using PeakLogix.App1.Portal.Server.Services;

namespace PeakLogix.App1.Portal.Server.Controllers;

[ApiController]
[Asp.Versioning.ApiVersion("1.0")] // Fully qualified to avoid ambiguity
[Route("api/portal/v{version:apiVersion}/[controller]")]
[Route("api/portal/[controller]")] // Fallback route without version
[ServiceFilter(typeof(ApiExceptionFilter<PortalSystemService>))]
public class SystemController : ControllerBase
{
	private readonly IPortalSystemService _systemService;

	public SystemController(IPortalSystemService systemService)
	{
		_systemService = systemService;
	}

	[HttpGet("[action]")]
	[AllowAnonymous]
	public async Task<ActionResult<object>> Ping()
	{
		return Ok(new PingResult(PortalConstants.ModuleId, ControllerContext.ActionDescriptor.ControllerName));
	}

	[HttpGet("[action]")]
	[AllowAnonymous]
	public async Task<ActionResult<object>> Health()
	{
		var health = await _systemService.Health();
		return Ok(health);
	}
}
