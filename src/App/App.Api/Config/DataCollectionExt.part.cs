using PeakLogix.LogixPro.App.Api.Context;
using Microsoft.Extensions.DependencyInjection;

namespace PeakLogix.LogixPro.App.Api.Config;

public static partial class DataCollectionExt
{
    static partial void AddDbServices(IServiceCollection services)
    {
        services.AddScoped<LogixProDb>();
    }
}
