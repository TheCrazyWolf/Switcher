using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;

namespace Switcher.Managers.Adapters;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class AdaptersManager
{
    public List<NetworkInterface> GetAdapters()
    {
        return NetworkInterface.GetAllNetworkInterfaces()
            .Where(x=> x.NetworkInterfaceType is NetworkInterfaceType.Wireless80211).ToList();
    }
}