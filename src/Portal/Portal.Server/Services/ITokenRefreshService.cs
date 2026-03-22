using PeakLogix.App1.Portal.Server.Models;

namespace PeakLogix.App1.Portal.Server.Services;

public interface ITokenRefreshService
{
	Task<TokenCacheEntry?> RefreshTokenAsync(string refreshToken);
}
