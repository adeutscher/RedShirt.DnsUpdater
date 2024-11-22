using RedShirt.DnsUpdater.Core.Services;

namespace RedShirt.DnsUpdater.Implementation.PublicAddress.Services;

public class PublicAddressService(IHttpClientFactory httpClientFactory) : IPublicAddressGetter
{
    public async Task<string?> GetPublicAddressAsync()
    {
        using var httpClient = httpClientFactory.CreateClient();
        var result = await httpClient.GetStringAsync("http://icanhazip.com");
        return result.Replace("\\r", "").Replace("\\n", "").Trim();
    }
}