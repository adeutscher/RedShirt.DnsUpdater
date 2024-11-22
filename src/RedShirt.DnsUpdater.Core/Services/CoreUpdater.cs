using Microsoft.Extensions.Options;

namespace RedShirt.DnsUpdater.Core.Services;

public interface ICoreUpdater
{
    Task UpdateAsync();
}

internal class CoreUpdater(
    IDnsRecordSetter setter,
    IPublicAddressGetter getter,
    IOptions<CoreUpdater.ConfigurationModel> options) : ICoreUpdater
{
    public async Task UpdateAsync()
    {
        var address = await getter.GetPublicAddressAsync();

        if (string.IsNullOrWhiteSpace(address))
        {
            return;
        }

        await setter.SetDnsRecordAsync(options.Value.Domain, address);
    }

    public class ConfigurationModel
    {
        public required string Domain { get; init; }
    }
}