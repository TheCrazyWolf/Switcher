using System.Diagnostics.CodeAnalysis;
using System.Management;
using Switcher.Models.Configs;

namespace Switcher.Managers.Adapters;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class IpManager
{
    public void SetDns(AdapterConfiguration configurationProxy, string adapterName)
    {
        var query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapterName}' AND IPEnabled = TRUE";
        using ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        foreach (var o in searcher.Get())
        {
            var adapter = (ManagementObject)o;
            ManagementBaseObject newIp = adapter.GetMethodParameters("EnableStatic");
            newIp["IPAddress"] = new [] { configurationProxy.IPv4.IPv4 };
            newIp["SubnetMask"] = new [] { configurationProxy.IPv4.Mask };
            adapter.InvokeMethod("EnableStatic", newIp, null);
            
            ManagementBaseObject newGateway = adapter.GetMethodParameters("SetGateways");
            newGateway["DefaultIPGateway"] = new [] { configurationProxy.IPv4.Gateway };
            newGateway["GatewayCostMetric"] = new [] { 1 };
            adapter.InvokeMethod("SetGateways", newGateway, null);
        }
    }
}