using System.Diagnostics.CodeAnalysis;
using System.Management;
using Microsoft.Win32;
using Switcher.Models.Configs;

namespace Switcher.Managers.Adapters;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class ApplyNetworkConfigManager
{
    public void SetGlobally(AdapterConfiguration configuration)
    {
        SetDns(configuration);
        SetIp(configuration);
        SetProxy(configuration);
    }
    
    public void SetDns(AdapterConfiguration configuration)
    {
        var query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{configuration.NetworkInterface.Description}' AND IPEnabled = TRUE";
        using ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        foreach (var o in searcher.Get())
        {
            var adapter = (ManagementObject)o;
            ManagementBaseObject newDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
            if (configuration.IsAutoDns) adapter.InvokeMethod("SetDNSServerSearchOrder", null);
            else
            {
                string[] dnsServers = [configuration.Dns.Main, configuration.Dns.Alternative];
                newDNS["DNSServerSearchOrder"] = dnsServers;
                adapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
            }
        }
    }
    
    public void SetIp(AdapterConfiguration configuration)
    {
        var query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{configuration.NetworkInterface.Description}' AND IPEnabled = TRUE";
        using ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        foreach (var o in searcher.Get())
        {
            var adapter = (ManagementObject)o;
            
            if (configuration.IsAutoIpv4) adapter.InvokeMethod("EnableDHCP", null);
            else
            {
                ManagementBaseObject newIp = adapter.GetMethodParameters("EnableStatic");
                newIp["IPAddress"] = new [] { configuration.IPv4.IPAddress };
                newIp["SubnetMask"] = new [] { configuration.IPv4.SubnetMask };
                adapter.InvokeMethod("EnableStatic", newIp, null);
            
                ManagementBaseObject newGateway = adapter.GetMethodParameters("SetGateways");
                newGateway["DefaultIPGateway"] = new [] { configuration.IPv4.DefaultIPGateway };
                newGateway["GatewayCostMetric"] = new [] { 1 };
                adapter.InvokeMethod("SetGateways", newGateway, null);
            }
        }
    }
    
    
    public void SetProxy(AdapterConfiguration configurationProxy)
    {
        const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(registryKeyPath, writable: true);
        if (key == null) return;
        key.SetValue("ProxyEnable", configurationProxy.UseProxy ? 1 : 0, RegistryValueKind.DWord);
        if (configurationProxy.UseProxy) key.SetValue("ProxyServer", configurationProxy.UseProxy, RegistryValueKind.String);
        else key.DeleteValue("ProxyServer", throwOnMissingValue: false);
    }
}