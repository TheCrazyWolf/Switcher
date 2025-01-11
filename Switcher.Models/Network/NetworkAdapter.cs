using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace Switcher.Models.Network;

public class NetworkAdapter 
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public OperationalStatus OperationalStatus { get; set; } = OperationalStatus.Unknown;
    public long Speed { get; set; } 
    public NetworkInterfaceType NetworkInterfaceType { get; set; } = NetworkInterfaceType.Unknown;
    public bool SupportsMulticast { get; set; } 
    public bool IsReceiveOnly { get; set; }
    
    public NetworkAdapter(NetworkInterface networkInterface)
    {
        Id = networkInterface.Id;
        Name = networkInterface.Name;
        Description = networkInterface.Description;
        OperationalStatus = networkInterface.OperationalStatus;
        Speed = networkInterface.Speed;
        NetworkInterfaceType = networkInterface.NetworkInterfaceType;
        SupportsMulticast = networkInterface.SupportsMulticast;
        IsReceiveOnly = networkInterface.IsReceiveOnly;
    }

    public NetworkAdapter()
    {
        
    }
}