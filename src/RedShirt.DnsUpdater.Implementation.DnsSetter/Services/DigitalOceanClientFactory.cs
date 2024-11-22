using DigitalOcean.API;
using Microsoft.Extensions.Options;

namespace RedShirt.DnsUpdater.Implementation.DnsSetter.Services;

internal interface IDigitalOceanClientFactory
{
    IDigitalOceanClient CreateDigitalOceanClient();
}

internal class DigitalOceanClientFactory(IOptions<ConfigurationModel> options) : IDigitalOceanClientFactory
{
    public IDigitalOceanClient CreateDigitalOceanClient()
    {
        if (string.IsNullOrWhiteSpace(options.Value.Token))
        {
            throw new Exception("Token is empty");
        }

        return new DigitalOceanClient(options.Value.Token);
    }
}