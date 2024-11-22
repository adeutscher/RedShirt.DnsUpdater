using DigitalOcean.API.Models.Requests;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RedShirt.DnsUpdater.Core.Services;

namespace RedShirt.DnsUpdater.Implementation.DnsSetter.Services;

internal class DigitalOceanDnsSetter(IDigitalOceanClientFactory clientFactory, IOptions<ConfigurationModel> options)
    : IDnsRecordSetter
{
    public async Task SetDnsRecordAsync(string domain, string address)
    {
        if (string.IsNullOrWhiteSpace(options.Value.Domain))
        {
            throw new ArgumentException("Domain must be set");
        }

        var client = clientFactory.CreateDigitalOceanClient();

        var data = await client.DomainRecords.GetAll(options.Value.Domain);
        if (data?.Any() != true)
        {
            throw new Exception("Failed to retrieve domain records");
        }

        var subject = domain == options.Value.Domain ? "@" : domain;
        var record = data.FirstOrDefault(d => d.Type == "A" && d.Name == subject);
        Console.WriteLine(JsonConvert.SerializeObject(record));
        if (record is null)
        {
            throw new Exception("Failed to retrieve domain record");
        }

        if (record.Data == address)
        {
            // Nothing to change
            return;
        }

        await client.DomainRecords.Update(options.Value.Domain, record.Id, new UpdateDomainRecord
        {
            Name = record.Name,
            Data = address,
            Type = "A"
        });
    }
}