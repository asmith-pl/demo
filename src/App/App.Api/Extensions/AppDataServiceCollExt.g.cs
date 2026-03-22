using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeakLogix.App1.App.Api.Config;
using PeakLogix.App1.App.Api.Context;
using PeakLogix.App1.Common.Data;

namespace PeakLogix.App1.App.Api.Extensions;

public static partial class AppApiServiceCollExt
{
	private static DbContextOptions<App1Db> _options;

	static partial void AddDataServices(IServiceCollection services, IConfiguration configuration)
	{
		var dataConfig = DataConfigBuilder.Build(configuration);
		services.AddSingleton(dataConfig);

		services.AddScoped(sp =>
		{
			if (_options == null)
			{
				var optionsBuilder = new DbContextOptionsBuilder<App1Db>();
				optionsBuilder.UseSqlServer(dataConfig.ConnectionString);
				optionsBuilder.AddInterceptors(sp.GetRequiredService<AuditingInterceptor>());
				_options = optionsBuilder.Options;
			}
			return _options;
		});

		services.AddScoped<App1Db>();
		services.AddScoped<AuditingInterceptor>();
	}
}
