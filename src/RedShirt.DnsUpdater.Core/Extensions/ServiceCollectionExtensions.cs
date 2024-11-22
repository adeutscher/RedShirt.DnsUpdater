using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedShirt.DnsUpdater.Core.Services;

namespace RedShirt.DnsUpdater.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDnsUpdaterCore(this IServiceCollection serviceCollection,
        IConfigurationRoot configuration)
    {
        return serviceCollection
            .AddSingleton<ICoreUpdater, CoreUpdater>()
            .Configure<CoreUpdater.ConfigurationModel>(configuration);
    }
}