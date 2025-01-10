using System.Diagnostics.CodeAnalysis;
using System.Management;
using Switcher.Models.Configs;

namespace Switcher.Managers.Adapters;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class DnsManager
{
    public void SetDns(AdapterConfiguration configurationProxy, string adapterName)
    {
        var query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapterName}' AND IPEnabled = TRUE";
        using ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        foreach (var o in searcher.Get())
        {
            var adapter = (ManagementObject)o;
            ManagementBaseObject newDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
            string[] dnsServers = [configurationProxy.Dns.Main, configurationProxy.Dns.Alternative];
            newDNS["DNSServerSearchOrder"] = dnsServers;
            adapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
        }
    }
}