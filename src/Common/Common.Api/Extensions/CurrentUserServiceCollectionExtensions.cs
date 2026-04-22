using PeakLogix.PickPro.Common.Api.Services;
using PeakLogix.PickPro.Common.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.PickPro.Common.Api.Extensions;

public static class CurrentUserServiceCollectionExtensions
{
	public static IServiceCollection AddCurrentUserServices(this IServiceCollection services)
	{
		services.AddHttpContextAccessor();
		services.AddScoped<ICurrentUserService, HttpContextCurrentUserService>();

		return services;
	}
}
