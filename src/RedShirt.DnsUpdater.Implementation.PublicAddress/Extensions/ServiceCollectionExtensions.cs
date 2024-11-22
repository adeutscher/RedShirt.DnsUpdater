using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedShirt.DnsUpdater.Core.Extensions;
using RedShirt.DnsUpdater.Core.Services;
using RedShirt.DnsUpdater.Implementation.PublicAddress.Services;

namespace RedShirt.DnsUpdater.Implementation.PublicAddress.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDnsUpdaterAddressGetter(this IServiceCollection serviceCollection,
        IConfigurationRoot configurationRoot)
    {
        return serviceCollection
            .ConfigureDnsUpdaterCore(configurationRoot)
            .AddHttpClient()
            .AddSingleton<IPublicAddressGetter, PublicAddressService>();
    }
}