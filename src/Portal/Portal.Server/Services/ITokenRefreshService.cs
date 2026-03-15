using PeakLogix.LogixPro.Portal.Server.Models;

namespace PeakLogix.LogixPro.Portal.Server.Services;

public interface ITokenRefreshService
{
	Task<TokenCacheEntry?> RefreshTokenAsync(string refreshToken);
}
