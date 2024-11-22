namespace RedShirt.DnsUpdater.Core.Services;

public interface IDnsRecordSetter
{
    Task SetDnsRecordAsync(string domain, string address);
}