using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedShirt.DnsUpdater.Core.Extensions;
using RedShirt.DnsUpdater.Core.Services;
using RedShirt.DnsUpdater.Implementation.DnsSetter.Services;

namespace RedShirt.DnsUpdater.Implementation.DnsSetter.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDnsUpdaterSetter(this IServiceCollection serviceCollection,
        IConfigurationRoot configurationRoot)
    {
        return serviceCollection
            .ConfigureDnsUpdaterCore(configurationRoot)
            .AddSingleton<IDigitalOceanClientFactory, DigitalOceanClientFactory>()
            .Configure<ConfigurationModel>(configurationRoot.GetSection("DigitalOcean"))
            .AddSingleton<IDnsRecordSetter, DigitalOceanDnsSetter>();
    }
}