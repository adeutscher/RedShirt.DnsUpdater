using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedShirt.DnsUpdater.Implementation.DnsSetter.Extensions;
using RedShirt.DnsUpdater.Implementation.PublicAddress.Extensions;

namespace RedShirt.DnsUpdater.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureProgram(this IServiceCollection services,
        IConfigurationRoot configurationRoot)
    {
        return services
            .ConfigureDnsUpdaterSetter(configurationRoot)
            .ConfigureDnsUpdaterAddressGetter(configurationRoot);
    }
}