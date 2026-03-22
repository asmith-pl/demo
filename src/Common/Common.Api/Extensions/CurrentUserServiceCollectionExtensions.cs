using PeakLogix.App1.Common.Api.Services;
using PeakLogix.App1.Common.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.App1.Common.Api.Extensions;

public static class CurrentUserServiceCollectionExtensions
{
	public static IServiceCollection AddCurrentUserServices(this IServiceCollection services)
	{
		services.AddHttpContextAccessor();
		services.AddScoped<ICurrentUserService, HttpContextCurrentUserService>();

		return services;
	}
}
