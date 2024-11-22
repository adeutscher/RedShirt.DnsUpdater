using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedShirt.DnsUpdater.Core.Services;
using RedShirt.DnsUpdater.Extensions;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariablesWithSegmentSupport()
    .Build();

var provider = new ServiceCollection()
    .ConfigureProgram(configuration)
    .BuildServiceProvider();

var handler = provider.GetRequiredService<ICoreUpdater>();
await handler.UpdateAsync();