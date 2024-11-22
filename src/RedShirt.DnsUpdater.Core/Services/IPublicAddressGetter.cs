namespace RedShirt.DnsUpdater.Core.Services;

public interface IPublicAddressGetter
{
    Task<string?> GetPublicAddressAsync();
}