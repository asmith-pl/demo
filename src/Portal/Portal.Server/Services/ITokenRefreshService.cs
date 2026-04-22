using PeakLogix.PickPro.Portal.Server.Models;

namespace PeakLogix.PickPro.Portal.Server.Services;

public interface ITokenRefreshService
{
	Task<TokenCacheEntry?> RefreshTokenAsync(string refreshToken);
}
