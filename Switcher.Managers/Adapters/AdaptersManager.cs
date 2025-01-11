using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using Switcher.Models.Network;

namespace Switcher.Managers.Adapters;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class AdaptersManager
{
    public List<NetworkAdapter> GetAdapters()
    {
        return NetworkInterface.GetAllNetworkInterfaces()
            .Select(ni => new NetworkAdapter(ni))
            .ToList();
    }
}