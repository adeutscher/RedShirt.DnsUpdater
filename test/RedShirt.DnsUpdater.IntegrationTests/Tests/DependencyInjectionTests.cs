using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedShirt.DnsUpdater.Core.Services;
using RedShirt.DnsUpdater.Extensions;

namespace RedShirt.DnsUpdater.IntegrationTests.Tests;

public class DependencyInjectionTests
{
    [Fact]
    public void Test_DependencyInjection()
    {
        var provider = new ServiceCollection()
            .ConfigureProgram(new ConfigurationBuilder().Build())
            .BuildServiceProvider();

        provider.GetRequiredService<ICoreUpdater>();
    }
}