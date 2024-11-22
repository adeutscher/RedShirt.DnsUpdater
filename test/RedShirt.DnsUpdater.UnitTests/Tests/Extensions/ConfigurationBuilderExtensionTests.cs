using Microsoft.Extensions.Configuration;
using RedShirt.DnsUpdater.Extensions;

namespace RedShirt.DnsUpdater.UnitTests.Tests.Extensions;

public class ConfigurationBuilderExtensionTests
{
    [Theory]
    [InlineData("A", "A", "B")]
    [InlineData("A__B", "A:B", "C")]
    [InlineData("X__Y", "X__Y", "Z")]
    [InlineData("DIGITAL_OCEAN__DOMAIN", "DigitalOcean:Domain", "foo")]
    [InlineData("DIGITAL_OCEAN__TOKEN", "DigitalOcean:Token", "bar")]
    [InlineData("C", "C", "D")]
    public void Test_AddEnvironmentVariablesWithSegmentSupport(string environmentKey, string configurationKey,
        string value)
    {
        var environment = new Dictionary<string, string>
        {
            [environmentKey] = value
        };

        TestUtilities.WrapEnvironment(environment, () =>
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariablesWithSegmentSupport()
                .Build();

            Assert.Equal(value, configuration[configurationKey]);
        });
    }
}