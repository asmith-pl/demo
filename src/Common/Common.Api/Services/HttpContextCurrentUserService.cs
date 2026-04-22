using System.Security.Claims;
using PeakLogix.PickPro.Common.Shared.Contracts;
using Microsoft.AspNetCore.Http;

namespace PeakLogix.PickPro.Common.Api.Services;

public sealed class HttpContextCurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
	public bool IsAuthenticated => httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated == true;

	public Guid? UserId
	{
		get
		{
			if (!IsAuthenticated)
				return null;

			var user = httpContextAccessor.HttpContext?.User;
			var userIdValue = user?.FindFirstValue("sub")
				?? user?.FindFirstValue("uid")
				?? user?.FindFirstValue(ClaimTypes.NameIdentifier);

			return Guid.TryParse(userIdValue, out var userId)
				? userId
				: null;
		}
	}
}
