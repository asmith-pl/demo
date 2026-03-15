using Microsoft.AspNetCore.Authorization;

namespace PeakLogix.LogixPro.Common.Api.Authorization;

public sealed class PermissionRequirement : IAuthorizationRequirement
{
	public PermissionRequirement(IReadOnlyCollection<string> permissions)
	{
		Permissions = permissions;
	}

	public IReadOnlyCollection<string> Permissions { get; }
}
